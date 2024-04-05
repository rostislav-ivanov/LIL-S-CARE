using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public static IEnumerable<Order> orders = new List<Order>
        {
           new Order
            {
                Id = 1,
                OrderNumber = "123456",
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                AddressDeliveryId = 1,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                DateShipping = DateTime.UtcNow,
                TrackingNumber = "1234567890",
                PaymentMethodId = 1,
            },
          new Order
             {
                Id = 2,
                OrderNumber = "123456x",
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 2,
                AddressDeliveryId = 2,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                DateShipping = DateTime.UtcNow,
                TrackingNumber = "1234567890x",
                PaymentMethodId = 2,
             },
        };
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(orders);
        }
    }
}