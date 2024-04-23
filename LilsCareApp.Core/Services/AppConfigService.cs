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

    }
}
