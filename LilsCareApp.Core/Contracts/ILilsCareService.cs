using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface ILilsCareService
    {
        Task AddToSubscribersAsync(SubscriberDTO subscriber);
        Task MessageFromClientAsync(ContactUsDTO message);

    }
}
