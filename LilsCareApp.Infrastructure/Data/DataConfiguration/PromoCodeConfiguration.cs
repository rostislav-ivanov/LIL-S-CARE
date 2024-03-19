using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        private readonly IEnumerable<PromoCode> promoCodes = new List<PromoCode>
        {
            new PromoCode
            {
                Id = 1,
                Code = "LILS10",
                Discount = 0.1m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = ConfigurationHelper.AppUser.Id
            },
            new PromoCode
            {
                Id = 2,
                Code = "LILS20",
                Discount = 0.2m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = ConfigurationHelper.AppUser.Id
            },
        };

        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.HasData(promoCodes);
        }
    }
}

