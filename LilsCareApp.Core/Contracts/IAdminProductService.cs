using LilsCareApp.Core.Models.AdminProducts;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminProductService
    {
        Task<bool> DeleteAsync(int id);
        Task<AdminProductsDTO> GetProductsQueryAsync(ProductSortType productSortType, string? search, int currentPage, int productsPerPage);
        Task ProductToShopAsync(int id);
    }
}
