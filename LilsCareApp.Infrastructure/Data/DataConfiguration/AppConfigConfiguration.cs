using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        private readonly AppConfig appConfig = new()
        {
            Id = 1,
            FreeShipping = 35.00m,
            AddressDeliveryPrice = 8.00m,
            ExchangeRateEUR = 1.9558m,
            ExchangeRateBGN = 1,
            ExchangeRateRON = 0.3930m
        };

        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.HasData(appConfig);
        }
    }
}