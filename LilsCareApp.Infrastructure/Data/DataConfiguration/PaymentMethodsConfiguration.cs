using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class PaymentMethodsConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        private readonly IEnumerable<PaymentMethod> paymentMethods =
        [
            new ()
            {
                Id = 1,
                TypeId = 1,
            },
            new ()
            {
                Id = 2,
                TypeId = 2,
            },
            new ()
            {
                Id = 3,
                TypeId = 3,
            },
        ];
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(paymentMethods);
        }
    }
}