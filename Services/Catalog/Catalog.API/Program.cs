using System.Net;
using Catalog.API.Extensions;
using Common.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Serilog; 

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(Logging.ConfigureLogger);
builder.Services.AddVersionedApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; options.SubstituteApiVersionInUrl = true; options.AssumeDefaultVersionWhenUnspecified = true; });

builder.Services.ConfigureHealthChecks(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureRepository();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(x=> 
    x.RegisterServicesFromAssemblies(typeof(Catalog.Application.IAssemblyReference).Assembly));

builder.Services.AddApiVersioning();

// identity server
var userPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddControllers(options => options.Filters.Add( new AuthorizeFilter(userPolicy)));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration.GetValue<string>("Auth:Authority");
        options.Audience = builder.Configuration.GetValue<string>("Auth:ApiName");
        options.MetadataAddress = "https://id-local.eshopping.com:44344/.well-known/openid-configuration";
        options.Configuration = new OpenIdConnectConfiguration();
        options.IncludeErrorDetails = true;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanRead", 
        policy => policy.RequireClaim("scope", "CatalogApi"));
});

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// app pipeline 
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

IdentityModelEventSource.ShowPII = true;
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseSwagger();
var nginxPath = "/catalog"; 
app.UseSwaggerUI(options =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"{nginxPath}/swagger/{description.GroupName}/swagger.json",
            $"Catalog API {description.GroupName.ToUpperInvariant()}");
        options.RoutePrefix = string.Empty;
    }

    options.DocumentTitle = "Catalog API Documentation";

});
app.MapControllers();
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();