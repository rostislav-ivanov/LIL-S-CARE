using LilsCareApp.Core.Models.AdminOrderDetails;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminOrderDetailsService
    {
        Task<AdminOrderDetailsDTO> GetOrderDetailsAsync(int id);
        Task AddTrackingCodeAsync(int id, string trackingNumber);
        Task ChangeStatusAsync(int id, int statusId);
        Task ChangePaymentAsync(int id, bool? isPaid);
        Task AddProductToOrderAsync(int id, int productId);
        Task<IEnumerable<ProductsNamesDTO>> GetProductsNameAsync();
    }
}
