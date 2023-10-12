using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Extensions;

public static class MigrationsManager
{
    private static int _numberOfRetries;

    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using var appContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
            try
            {
                appContext.Database.Migrate();
            }
            catch (SqlException)
            {
                if (_numberOfRetries < 6)
                {
                    Thread.Sleep(10000);

                    _numberOfRetries++;
                    Console.WriteLine($"The server was not found or was not accessible. Retrying... #{_numberOfRetries}");

                    MigrateDatabase(host);
                }

                throw;
            }
        }

        return host;
    }
}