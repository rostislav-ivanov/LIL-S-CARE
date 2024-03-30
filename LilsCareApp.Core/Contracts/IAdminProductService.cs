
using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByIdAscAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByIdDescAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByIsShowAscAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByIsShowDescAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByNameAscAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByNameDescAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByPriceAscAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByPriceDescAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByQuantityAscAsync();
        Task<IEnumerable<ProductDTO>> GetProductsOrderByQuantityDescAsync();
    }
}
