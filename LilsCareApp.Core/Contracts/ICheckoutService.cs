using LilsCareApp.Core.Models.Checkout;

namespace LilsCareApp.Core.Contracts
{
    public interface ICheckoutService
    {
        Task<AddressDeliveryDTO?> GetAddressDeliveryAsync(string userId);
        Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync();
        Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesByCityAsync(string city, int? shippingProviderId);
        Task<IEnumerable<string>> GetShippingCitiesAsync(int shippingProvidersId);
        Task<OrderSummaryDTO> CheckoutSaveAsync(OrderDTO checkout, string userId);
    }
}