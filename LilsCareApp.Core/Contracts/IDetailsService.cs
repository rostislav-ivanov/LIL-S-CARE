using LilsCareApp.Core.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface IDetailsService
    {
        Task<DetailsDTO> GetDetailsByIdAsync(int productId, string appUserId);
        Task SaveReviewAsync(AddReviewDTO review);
        Task<AddReviewDTO?> GetReviewAsync(int productId, string userId);
    }
}
