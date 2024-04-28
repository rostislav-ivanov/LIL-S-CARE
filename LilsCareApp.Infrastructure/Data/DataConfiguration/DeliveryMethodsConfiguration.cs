using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class DeliveryMethodsConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        private readonly IEnumerable<DeliveryMethod> deliveryMethods =
        [
            new () { Id = 1, NameId = 1 },
            new () { Id = 2, NameId = 2 },
        ];

        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.HasData(deliveryMethods);
        }
    }
}