using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface ILilsCareService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(string userId);
        Task AddToSubscribersAsync(SubscriberDTO subscriber);
        Task MessageFromClientAsync(MessageFromClientDTO message);
        Task AddToWishAsync(int productId, string userId);
        Task RemoveFromWishAsync(int productId, string userId);
        Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId);
        Task AddToCartAsync(int productId, string userId);
        Task RemoveFromCartAsync(int productId, string userId);
        Task<int> GetCountInBagAsync(string userId);
    }
}
