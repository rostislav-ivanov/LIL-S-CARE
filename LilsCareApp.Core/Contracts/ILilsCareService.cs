using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface ILilsCareService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(string userId);
        Task<int> GetCountInBagAsync(string userId);
        Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(string userId);
    }
}
