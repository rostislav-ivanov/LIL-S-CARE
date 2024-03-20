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
                Code = "-10 % за регистрация",
                Discount = 0.1m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = ConfigurationHelper.AppUser.Id
            },
            new PromoCode
            {
                Id = 2,
                Code = "-20 % отстъпка",
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

