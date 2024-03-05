using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface ILilsCareService
    {
        Task AddToSubscribersAsync(SubscriberDTO subscriber);
        Task AddToWishAsync(int id, string userId);
        Task RemoveFromWishAsync(int id, string userId);
        Task<IEnumerable<ProductDTO>> GetAllAsync(string userId);
        Task<int> GetCountInBagAsync(string userId);
        Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId);
        Task MessageFromClientAsync(MessageFromClientDTO message);
    }
}
