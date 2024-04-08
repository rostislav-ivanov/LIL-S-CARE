using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class AddressDeliveriesConfiguration : IEntityTypeConfiguration<AddressDelivery>
    {
        private readonly IEnumerable<AddressDelivery> addressDeliveries = new List<AddressDelivery>
        {
            new AddressDelivery
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "0888888888",
                PostCode = "1000",
                Address= "bul. Vitosha",
                Town = "Sofia",
                District = "Sofia",
                Country = "Bulgaria",
                ShippingOfficeId = 1,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
            new AddressDelivery
            {
                Id = 2,
                FirstName = "Petar",
                LastName = "Petrov",
                PhoneNumber = "0888888888",
                PostCode = "1000",
                Address= "bul. Vitosha",
                Town = "Sofia",
                District = "Sofia",
                Country = "Bulgaria",
                ShippingOfficeId = 2,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },

        };
        public void Configure(EntityTypeBuilder<AddressDelivery> builder)
        {
            builder.HasData(addressDeliveries);
        }
    }
}