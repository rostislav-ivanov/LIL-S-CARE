using LilsCareApp.Core.Models.AdminProducts;
using LilsCareApp.Core.Models.Products;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminDetailsService
    {
        Task AddNewCategoryAsync(string newCategory);
        Task AddProductImageAsync(int id, string filePath);
        Task AddQuantityAsync(int id, int quantity);
        Task AddRemoveCategoryAsync(int id, int categoryId);
        Task AddSectionAsync(int id);
        Task<AdminDetailsDTO> CreateProductAsync();
        Task<AdminDetailsDTO> CreateProductByTemplateAsync(int id);
        Task DeleteCategoryAsync(int id, int categoryId);
        Task DeleteSectionAsync(int productId, int sectionId);
        Task EditNameAsync(int id, string name);
        Task EditOptionalAsync(int id, string optional);
        Task EditPriceAsync(int id, decimal price);
        Task EditSectionAsync(int sectionId, string title, string description);
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<AdminDetailsDTO> GetProductByIdAsync(int id);
        Task MoveImageLeftAsync(int id, int imageOrder);
        Task MoveImageRightAsync(int id, int imageOrder);
        Task MoveSectionDownAsync(int id, int sectionId);
        Task MoveSectionUpAsync(int id, int sectionOrder);
        Task<string?> RemoveImageAsync(int id, int sectionOrder);
    }
}
