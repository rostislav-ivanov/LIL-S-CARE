using LilsCareApp.Core.Models.Checkout;

namespace LilsCareApp.Core.Contracts
{
    public interface ICheckoutService
    {
        Task<IDeliveryDTO> GetAddressDeliveryAsync(string userId);
        Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesAsync();
        Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync();
    }
}