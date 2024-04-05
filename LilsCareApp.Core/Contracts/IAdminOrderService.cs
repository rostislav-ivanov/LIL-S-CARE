using LilsCareApp.Core.Models.AdminOrders;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminOrderService
    {
        Task<IEnumerable<AdminOrderDTO>> GetOrdersAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByCustomerAscAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByCustomerDescAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByDateAscAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByDateDescAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByOrderAscAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByOrderDescAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByPaymentAscAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByPaymentDescAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByStatusOrderAscAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByStatusOrderDescAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByTotalAscAsync();
        Task<IEnumerable<AdminOrderDTO>> GetOrdersOrderByTotalDescAsync();
    }
}
