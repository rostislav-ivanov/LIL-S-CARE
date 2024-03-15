using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ShippingProvidersConfiguration : IEntityTypeConfiguration<ShippingProvider>
    {
        private readonly IEnumerable<ShippingProvider> shippingProviders = new List<ShippingProvider>
        {
            new ShippingProvider
            {
                Id = 1,
                Name = "До офис Еконт / Спиди",
                Price = 6.50m,
                Description = "2-3 работни дни",
                IsDeliveryToAddress = false
            },
            new ShippingProvider
            {
                Id = 2,
                Name = "До адрес - Еконт" ,
                Price = 8.50m,
                Description = "2-3 работни дни",
                IsDeliveryToAddress = true
            },
        };

        public void Configure(EntityTypeBuilder<ShippingProvider> builder)
        {
            builder.HasData(shippingProviders);
        }
    }
}