using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminOrders;
using Microsoft.AspNetCore.Mvc;
using static LilsCareApp.Infrastructure.DataConstants.Order;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class OrdersController : AdminController
    {
        public readonly IAdminOrderService _adminOrderService;

        public OrdersController(IAdminOrderService adminOrderService)
        {
            _adminOrderService = adminOrderService;
        }

        public async Task<IActionResult> Index(OrderSortType orderSortType,
            string? status,
            bool? payment,
            string? search,
            int currentPage = 1,
            int ordersPerPage = OrdersPerPages)
        {
            var orders = await _adminOrderService.GetOrdersQueryAsync(orderSortType, status, payment, search, currentPage, ordersPerPage);

            return View(orders);
        }

    }
}
