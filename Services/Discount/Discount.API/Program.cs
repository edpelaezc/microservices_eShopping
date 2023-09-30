using Discount.API.Extensions;
using Discount.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRepository();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(x=> x.RegisterServicesFromAssemblies(typeof(Discount.Application.IAssemblyReference).Assembly));
builder.Services.AddGrpc();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<DiscountService>();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync(
            "Communication with gRPC endpoints must be made through a gRPC client.");
    });
});

app.Run();