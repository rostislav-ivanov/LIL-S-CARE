using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IDetailsService
    {
        Task<DetailsDTO> GetDetailsById(int productId, string appUserId);
        Task AddReviewAsync(AddReviewDTO review);
    }
}
