using LilsCareApp.Core.Models.Account;

namespace LilsCareApp.Core.Contracts
{
    public interface IAccountService
    {
        Task<MyAccountDTO?> GetMyAccountAsync(string userId);
        Task<dynamic> GetUserImagePathAsync(string userId);
        Task UpdateMyAccountAsync(string userId, MyAccountDTO myAccount);
        Task<IEnumerable<MyAddressDTO>> GetMyAddressesAsync(string userId);
        Task AddAddressAsync(string userId, AddressDTO model);
        Task<AddressDTO?> GetAddressAsync(int addressId);
        Task UpdateAddressAsync(string userId, AddressDTO model);
        Task DeleteAddressAsync(int addressId);
        Task SetDefaultAddressAsync(string userId, int addressId);
        Task<OfficeDTO?> GetOfficeAsync(int addressId);
        Task UpdateOfficeAsync(string userId, OfficeDTO model);
    }
}
