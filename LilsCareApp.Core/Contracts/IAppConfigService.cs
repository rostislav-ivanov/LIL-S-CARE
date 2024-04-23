
namespace LilsCareApp.Core.Contracts
{
    public interface IAppConfigService
    {
        Task<decimal> GetExchangeRateAsync(string language);
    }
}