using LilsCareApp.Core.Contracts;
using LilsCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Services
{
    public class AppConfigService : IAppConfigService
    {
        private readonly ApplicationDbContext _context;

        public AppConfigService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetExchangeRateAsync(string language)
        {
            var appConfig = await _context.AppConfigs.FirstOrDefaultAsync();

            if (appConfig == null)
            {
                throw new InvalidOperationException("AppConfig is not found.");
            }

            decimal exchangeRate = language switch
            {
                English => appConfig.ExchangeRateEUR,
                Bulgarian => appConfig.ExchangeRateBGN,
                Romanian => appConfig.ExchangeRateRON,
                _ => throw new InvalidOperationException("Invalid language.")
            };

            return exchangeRate;
        }

        public async Task<decimal> GetAddressDeliveryPriceAsync(string language)
        {
            decimal exchangeRate = await GetExchangeRateAsync(language);

            decimal addressDeliveryPrice = await _context.AppConfigs
                .Select(x => x.AddressDeliveryPrice)
                .FirstOrDefaultAsync();

            return addressDeliveryPrice / exchangeRate;
        }

        public async Task<decimal> GetFreeShipping(string language)
        {
            decimal exchangeRate = await GetExchangeRateAsync(language);

            decimal freeShipping = await _context.AppConfigs
                .Select(x => x.FreeShipping)
                .FirstOrDefaultAsync();

            return freeShipping / exchangeRate;
        }
    }
}
