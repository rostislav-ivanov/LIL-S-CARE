using LilsCareApp.Core.Models.Checkout;

namespace LilsCareApp.Core.Contracts
{
    public interface ICheckoutService
    {
        Task<IDeliveryDTO> GetAddressDeliveryAsync(string userId);
        Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync();
        Task<ShippingOfficeDTO?> GetShippingOfficeByIdAsync(int officeId);
        Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesByCityAsync(string city, int? shippingProviderId);
        Task<IEnumerable<string>> GetShippingCitiesAsync(int shippingProvidersId);
        Task CheckoutSaveAsync(OrderDTO? checkout, string userId);
    }
}