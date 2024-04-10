using LilsCareApp.Core.Models.Checkout;

namespace LilsCareApp.Services
{
    public interface IGuestService
    {
        void AddToCart(int productId, int quantity);
        void ClearBag();
        void DeleteProductFromCart(int id);
        int GetCountInBag();
        Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync();
        Task<string> CheckoutSaveAsync(OrderDTO order);
    }
}
