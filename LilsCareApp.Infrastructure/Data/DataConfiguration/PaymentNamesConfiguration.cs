using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class PaymentNamesConfiguration : IEntityTypeConfiguration<PaymentName>
    {
        private readonly IEnumerable<PaymentName> paymentTypes =
        [
            new ()
            {
                Id = 1,
                NameEN = "Cash on delivery",
                NameBG = "Плащане при доставка",
                NameRO = "Plata la livrare",
                PaymentMethodId = 1
            },
            new ()
            {
                Id = 2,
                NameEN = "With card",
                NameBG = "С карта",
                NameRO = "Cu cardul",
                PaymentMethodId = 2
            },
            new ()
            {
                Id = 3,
                NameEN = "Bank transfer",
                NameBG = "Банков превод",
                NameRO = "Transfer bancar",
                PaymentMethodId = 3
            }
        ];

        public void Configure(EntityTypeBuilder<PaymentName> builder)
        {
            builder.HasData(paymentTypes);
        }
    }
}


