using LilsCareApp.Core.Models.Account;

namespace LilsCareApp.Core.Contracts
{
    public interface IAccountService
    {
        Task<MyAccountDTO?> GetMyAccountAsync(string userId);
        Task<dynamic> GetUserImagePathAsync(string userId);
        Task UpdateMyAccountAsync(string userId, MyAccountDTO myAccount);
    }
}
