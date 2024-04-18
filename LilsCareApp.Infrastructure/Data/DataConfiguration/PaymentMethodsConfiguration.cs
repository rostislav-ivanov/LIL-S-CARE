using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class PaymentMethodsConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        private readonly IEnumerable<PaymentMethod> paymentMethods = new List<PaymentMethod>
        {
            new PaymentMethod { Id = 1, Type = "Плащане при доставка" },
            new PaymentMethod { Id = 2, Type = "С карта" },
            new PaymentMethod { Id = 3, Type = "Банков превод" }
        };
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(paymentMethods);
        }
    }
}