using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ShippingOfficeConfiguration : IEntityTypeConfiguration<ShippingOffice>
    {
        private readonly IEnumerable<ShippingOffice> shippingOffice = new List<ShippingOffice>
        {
            new ShippingOffice
            {
                Id = 1,
                City = "Sofia",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 2,
                City = "Sofia",
                OfficeAddress = "bul. Hristo Botev 20",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 3,
                City = "Varna",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 4,
                City = "Burgas",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 5,
                City = "Ruse",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 6,
                City = "Sofia",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 7,
                City = "Sofia",
                OfficeAddress = "bul. Hristo Botev 30",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 8,
                City = "Sofia",
                OfficeAddress = "bul. Bozveli 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 9,
                City = "Burgas",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 10,
                City = "Ruse",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            }

        };

        public void Configure(EntityTypeBuilder<ShippingOffice> builder)
        {
            builder.HasData(shippingOffice);
        }
    }
}
