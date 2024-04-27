using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.GuestUser;

namespace LilsCareApp.Core.Contracts
{
    public interface IHttpContextManager
    {
        GuestSession? GetSession();
        void SetSession(GuestSession? session);

        AddressOrderDTO? GetSessionAddress();

        void SetSessionAddress(AddressOrderDTO? address);

        string GetLanguage();
    }
}
