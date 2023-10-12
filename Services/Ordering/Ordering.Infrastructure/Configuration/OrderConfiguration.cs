using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasData
        (
            new Order()
            {
                Id = 1,
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
                CreatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local),
                LastModifiedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local)
            }
        );
    }
}