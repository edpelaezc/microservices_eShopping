using Catalog.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHealthChecks(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureRepository();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(x=> x.RegisterServicesFromAssemblies(typeof(Catalog.Application.IAssemblyReference).Assembly));

builder.Services.AddApiVersioning();
builder.Services.AddControllers();

var app = builder.Build();

// app pipeline 
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();