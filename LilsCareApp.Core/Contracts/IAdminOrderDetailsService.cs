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
        Task RemoveProductFromOrderAsync(int id, int productId);
        Task AddQuantityToProductAsync(int id, int productId, int quantity);
        Task EditDiscountAsync(int id, decimal discount);
        Task AddOfficeDeliveryAsync(AdminOrderDetailsDTO model);
        Task AddHomeDeliveryAsync(AdminOrderDetailsDTO model);
    }
}
