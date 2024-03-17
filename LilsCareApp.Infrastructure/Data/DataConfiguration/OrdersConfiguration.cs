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
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                AddressDeliveryId = 1,
                AppUserId = ConfigurationHelper.AppUser.Id,
                DateShipping = DateTime.UtcNow,
                TrackingNumber = "1234567890",
                PaymentMethodId = 1,
            },
          new Order
             {
                Id = 2,
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 2,
                AddressDeliveryId = 2,
                AppUserId = ConfigurationHelper.AppUser.Id,
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