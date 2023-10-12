using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data;

public static class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContext> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded.");
        }
    }
    
    private static IEnumerable<Order> GetOrders()
    {
        return new List<Order>
        {
            new()
            {
                UserName = "edpelaezc",
                FirstName = "Eduardo",
                LastName = "Pelaez",
                EmailAddress = "edpelaezc@eshop.net",
                AddressLine = "Guatemala",
                Country = "Guatemala",
                TotalPrice = 750,
                State = "GUA",
                ZipCode = "560001",
                CardName = "Visa",
                CardNumber = "1234567890123456",
                CreatedBy = "ed",
                Expiration = "12/25",
                CVV = "123",
                PaymentMethod = 1,
                LastModifiedBy = "ed",
                LastModifiedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local)
            }
        };
    }
}