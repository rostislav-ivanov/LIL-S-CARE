using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminDetailsService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<DetailsDTO> GetProductByIdAsync(int id);
    }
}
