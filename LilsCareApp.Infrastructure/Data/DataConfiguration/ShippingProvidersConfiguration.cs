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
                Name = "Еконт",
            },
            new ShippingProvider
            {
                Id = 2,
                Name = "Спиди"
            },
        };

        public void Configure(EntityTypeBuilder<ShippingProvider> builder)
        {
            builder.HasData(shippingProviders);
        }
    }
}