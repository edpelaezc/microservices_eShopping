using Basket.Core.Repositories;
using Basket.Infrastructure.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace Basket.API.Extensions;

public static class ServiceExtensions
{
    public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration["CacheSettings:ConnectionString"];
        });
    }
    
    public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks().AddRedis
        (
            configuration["CacheSettings:ConnectionString"]!,
            "Basket Redis cache Health Check",
            HealthStatus.Degraded
        );
    }
    
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen((options =>
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket API", Version = "v1" })));
    }
    
    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IBasketRepository, BasketRepository>();
    }
}