using LilsCareApp.Core.Models.AdminProductDetails;
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
        Task<AdminProductDetailsDTO> CreateProductAsync();
        Task<AdminProductDetailsDTO> CreateProductByTemplateAsync(int id);
        Task DeleteCategoryAsync(int categoryId);
        Task DeleteSectionAsync(int productId, int sectionId);
        Task EditNameAsync(int id, string name, Language language);
        Task EditOptionalAsync(int id, string optional, Language language);
        Task EditPriceAsync(int id, decimal price);
        Task EditSectionAsync(int sectionId, string title, string description, Language language);
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(Language language);
        Task<AdminProductDetailsDTO> GetProductByIdAsync(int id, Language language);
        Task MoveImageLeftAsync(int id, int imageOrder);
        Task MoveImageRightAsync(int id, int imageOrder);
        Task MoveSectionDownAsync(int id, int sectionId);
        Task MoveSectionUpAsync(int id, int sectionOrder);
        Task<string?> RemoveImageAsync(int id, int sectionOrder);
    }
}
