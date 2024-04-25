using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public static IEnumerable<Order> orders =
        [
           new ()
            {
                Id = 1,
                OrderNumber = "123456",
                Language = "bg",
                ExchangeRate = 1.00m,
                CreatedOn = DateTime.ParseExact("28/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusOrderId = 1,
                AddressDeliveryId = 1,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                DateShipping = DateTime.ParseExact("29/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrackingNumber = "1234567890",
                PaymentMethodId = 1,
                DeliveryMethodId = 1,
                ShippingPrice = 5.00m,
                Discount = 10.00m,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
            },
          new ()
             {
                Id = 2,
                OrderNumber = "123456x",
                Language = "en",
                ExchangeRate = 1.95m,
                CreatedOn = DateTime.ParseExact("25/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusOrderId = 2,
                AddressDeliveryId = 2,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                PaymentMethodId = 2,
                DeliveryMethodId = 2,
                ShippingPrice = 5.00m,
                Discount = 0.00m,
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "1234567890x",
             },
        ];

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(orders);
        }
    }
}