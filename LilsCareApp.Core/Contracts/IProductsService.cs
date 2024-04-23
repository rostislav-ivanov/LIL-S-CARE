using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.Products;

namespace LilsCareApp.Core.Contracts
{
    public interface IProductsService
    {
        Task<ProductsDTO> GetProductsQueryAsync(string userId, int? categoryId, int currentPage, int productsPerPage);
        Task<IList<CategoryDTO>> GetCategoriesAsync();
        Task AddRemoveWishAsync(int productId, string userId);
        Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId);
        Task AddToCartAsync(int productId, string userId, int quantity);
        Task<int> GetCountInBagAsync(string userId);
        Task DeleteProductFromCartAsync(int id, string userId);
        Task<IEnumerable<ProductDTO>> GetMyWishesAsync(string userId);
        Task MigrateProductsInBagAsync(string userId, IEnumerable<ProductsInBagDTO> guestProduct);
        Task<IEnumerable<ProductDTO>> GetAllAsync(string userId);
    }
}
