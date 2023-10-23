using Basket.API.Extensions;
using Basket.Application.GrpcService;
using Discount.Grpc.Protos;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHealthChecks(builder.Configuration);

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ct, cfg)=>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

builder.Services.AddRedis(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureRepository();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<DiscountGrpcService>();
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
    (o => o.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]));

builder.Services.AddMediatR(x=> x.RegisterServicesFromAssemblies(typeof(Basket.Application.IAssemblyReference).Assembly));
builder.Services.AddApiVersioning();
builder.Services.AddControllers();

var app = builder.Build();

// app pipeline 
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket API V1"));
app.MapControllers();
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();