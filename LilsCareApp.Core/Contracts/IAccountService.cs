using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;

namespace LilsCareApp.Core.Contracts
{
    public interface IAccountService
    {
        Task<MyAddressDTO?> GetMyAccountAsync(string userId);
        Task<dynamic> GetUserImagePathAsync(string userId);
        Task UpdateMyAccountAsync(string userId, MyAddressDTO myAccount);



        Task<IEnumerable<DeliveryAddressDTO>> GetMyAddressesAsync(string userId);
        Task DeleteAddressAsync(int addressId);
        Task SetDefaultAddressAsync(string userId, int addressId);
        Task<IEnumerable<ShippingProviderDTO>> GetShippingProvidersAsync();
        Task<IEnumerable<string>> GetShippingProviderCitiesAsync(int shippingProviderId);
        Task<IEnumerable<ShippingOfficeDTO>> GetShippingOfficesAsync(int? shippingProviderId, string city);
        Task AddOfficeDeliveryAsync(string userId, OfficeDTO model);
        Task EditOfficeDeliveryAsync(string userId, OfficeDTO model);
        Task AddAddressDeliveryAsync(string userId, AddressDTO address);
        Task EditAddressDeliveryAsync(string userId, AddressDTO model);
        Task<DeliveryAddressesDTO> GetAddressDeliveryAsync(int addressId);
    }
}
