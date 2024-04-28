
namespace LilsCareApp.Core.Contracts
{
    public interface IAppConfigService
    {
        Task<decimal> GetExchangeRateAsync(string language);
        Task<decimal> GetAddressDeliveryPriceAsync(string language);
        Task<decimal> GetFreeShipping(string language);
    }
}