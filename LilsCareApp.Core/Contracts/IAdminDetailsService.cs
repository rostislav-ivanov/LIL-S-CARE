using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminDetailsService
    {
        Task AddProductImageAsync(int id, string filePath);
        Task<DetailsDTO> CreateProductAsync();
        Task<DetailsDTO> CreateProductByTemplateAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<DetailsDTO> GetProductByIdAsync(int id);
        Task MoveImageLeftAsync(int id, int imageOrder);
        Task MoveImageRightAsync(int id, int imageOrder);
        Task<string?> RemoveImageAsync(int id, int imageId);
    }
}
