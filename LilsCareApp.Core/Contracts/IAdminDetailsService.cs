using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminDetailsService
    {
        Task AddProductImageAsync(int id, string filePath);
        Task AddRemoveCategoryAsync(int id, int categoryId);
        Task AddSectionAsync(int id);
        Task<DetailsDTO> CreateProductAsync();
        Task<DetailsDTO> CreateProductByTemplateAsync(int id);
        Task DeleteSectionAsync(int productId, int sectionId);
        Task EditNameAsync(int id, string name);
        Task EditSectionAsync(int sectionId, string title, string description);
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<DetailsDTO> GetProductByIdAsync(int id);
        Task MoveImageLeftAsync(int id, int imageOrder);
        Task MoveImageRightAsync(int id, int imageOrder);
        Task MoveSectionDownAsync(int id, int sectionId);
        Task MoveSectionUpAsync(int id, int sectionOrder);
        Task<string?> RemoveImageAsync(int id, int sectionOrder);
    }
}
