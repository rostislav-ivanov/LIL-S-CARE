using LilsCareApp.Core.Models.Home;

namespace LilsCareApp.Core.Contracts
{
    public interface IHomeService
    {
        Task AddToSubscribersAsync(SubscriberDTO subscriber);
        Task MessageFromClientAsync(ContactUsDTO message);
        Task AddPromoCodeForFirstRegistrationAsync(string userId);
        Task EmailConfirmationAsync(string userId);
    }
}
