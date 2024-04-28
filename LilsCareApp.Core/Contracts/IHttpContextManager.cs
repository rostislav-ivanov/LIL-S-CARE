using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.GuestUser;

namespace LilsCareApp.Core.Contracts
{
    public interface IHttpContextManager
    {
        GuestSession? GetSessionGuest();
        void SetSessionGuest(GuestSession? session);

        AddressOrderDTO? GetSessionAddress();

        void SetSessionAddress(AddressOrderDTO? address);

        OrderDTO? GetSessionOrder();

        void SetSessionOrder(OrderDTO? order);

        string GetLanguage();
    }
}
