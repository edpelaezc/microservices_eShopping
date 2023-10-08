using Discount.API.Extensions;
using Discount.API.Services;
using Discount.Infrastructure.Extensions;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRepository();
builder.Services.AddMediatR(x=> x.RegisterServicesFromAssemblies(typeof(Discount.Application.IAssemblyReference).Assembly));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddGrpc();

var app = builder.Build();

// app pipeline 
if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseRouting();
app.MapGrpcService<DiscountService>();
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(
        "Communication with gRPC endpoints must be made through a gRPC client.");
});

app.MigrateDatabase<Program>();
app.Run();