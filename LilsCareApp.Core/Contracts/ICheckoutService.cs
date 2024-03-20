using LilsCareApp.Core.Models.Checkout;

namespace LilsCareApp.Core.Contracts
{
    public interface ICheckoutService
    {
        Task<AddressDeliveryDTO?> GetAddressDeliveryAsync(string userId);
        Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync();
        Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesByCityAsync(string city, int? shippingProviderId);
        Task<IEnumerable<string>> GetShippingCitiesAsync(int shippingProvidersId);
        Task<string> CheckoutSaveAsync(OrderDTO checkout, string userId);
        Task<OrderSummaryDTO> OrderSummaryAsync(string orderSNumber);
    }
}