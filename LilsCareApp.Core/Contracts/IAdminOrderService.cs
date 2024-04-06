using LilsCareApp.Core.Models.AdminOrders;

namespace LilsCareApp.Core.Contracts
{
    public interface IAdminOrderService
    {
        Task<AdminOrdersDTO> GetOrdersQueryAsync(OrderSortType orderSortType, string? status, bool? payment, string? search, int currentPage, int ordersPerPage);
        Task<IEnumerable<StatusOrderDTO>> GetStatusesOrderAsync();
    }
}
