using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class DeliveryNamesConfiguration : IEntityTypeConfiguration<DeliveryName>
    {
        public readonly IEnumerable<DeliveryName> deliveryNames =
        [
            new ()
            {
                Id = 1,
                NameEN = "Office delivery",
                NameBG = "Доставка до офис на куриер",
                NameRO = "Livrare la birou",
                DeliveryMethodId = 1,
            },
            new ()
            {
                Id = 2,
                NameEN = "Home delivery",
                NameBG = "Доставка до адрес на клиент",
                NameRO = "Livrare la domiciliu",
                DeliveryMethodId = 2,
            },
        ];

        public void Configure(EntityTypeBuilder<DeliveryName> builder)
        {
            builder.HasData(deliveryNames);
        }
    }
}