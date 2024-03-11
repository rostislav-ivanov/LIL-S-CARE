using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IDetailsService
    {
        Task<DetailsDTO> GetDetailsByIdAsync(int productId, string appUserId);
        Task AddReviewAsync(AddReviewDTO review);
        Task<AddReviewDTO?> GetReviewByIdAsync(int productId, string userId);
    }
}
