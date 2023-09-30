using Discount.Core.Repositories;
using Discount.Infrastructure.Repositories;

namespace Discount.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IDiscountRepository, DiscountRepository>();
    }
}