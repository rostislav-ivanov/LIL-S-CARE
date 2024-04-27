using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;

namespace LilsCareApp.Core.Contracts
{
    public interface IAccountService
    {
        Task<MyAddressDTO?> GetMyAccountAsync(string userId);
        Task<string> GetUserImagePathAsync(string userId);
        Task UpdateMyAccountAsync(string userId, MyAddressDTO myAccount);
        //Task<IEnumerable<MyOrderDTO>> GetMyOrdersAsync(string userId);
        Task<IEnumerable<DeliveryAddressDTO>> GetMyAddressesAsync(string userId);
        Task RemoveAddressFromAppUserAsync(int addressId);
        Task SetDefaultAddressAsync(string userId, int addressId);
        Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync();
        Task<IEnumerable<string>> GetShippingProviderCitiesAsync(int shippingProviderId);
        Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesAsync(int? shippingProviderId, string city);
        //Task AddOfficeDeliveryAsync(string userId, OfficeDTO model);
        //Task EditOfficeDeliveryAsync(string userId, OfficeDTO model);
        Task AddAddressDeliveryAsync(string userId, AddressOrderDTO address);
        Task EditAddressDeliveryAsync(string userId, AddressOrderDTO model);
        Task<AddressOrderDTO> GetAddressDeliveryAsync(int addressId);
        Task<string?> GetEmailUser(string userId);
        Task<string?> GetAddressOwnerId(int addressId);
    }
}
