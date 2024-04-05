using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminOrders;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class OrdersController : AdminController
    {
        public readonly IAdminOrderService _adminOrderService;

        public OrdersController(IAdminOrderService adminOrderService)
        {
            _adminOrderService = adminOrderService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AdminOrderDTO> orders = await _adminOrderService.GetOrdersAsync();

            return View(orders);
        }

        public async Task<IActionResult> OrderBy(int orderBy)
        {

            OrderSortType sort = (OrderSortType)orderBy;

            IEnumerable<AdminOrderDTO> orders = [];
            switch (sort)
            {
                case OrderSortType.OrderAsc:
                    orders = await _adminOrderService.GetOrdersOrderByOrderAscAsync();
                    break;
                case OrderSortType.OrderDesc:
                    orders = await _adminOrderService.GetOrdersOrderByOrderDescAsync();
                    break;
                case OrderSortType.DateAsc:
                    orders = await _adminOrderService.GetOrdersOrderByDateAscAsync();
                    break;
                case OrderSortType.DateDesc:
                    orders = await _adminOrderService.GetOrdersOrderByDateDescAsync();
                    break;
                case OrderSortType.CustomerAsc:
                    orders = await _adminOrderService.GetOrdersOrderByCustomerAscAsync();
                    break;
                case OrderSortType.CustomerDesc:
                    orders = await _adminOrderService.GetOrdersOrderByCustomerDescAsync();
                    break;
                case OrderSortType.PaymentAsc:
                    orders = await _adminOrderService.GetOrdersOrderByPaymentAscAsync();
                    break;
                case OrderSortType.PaymentDesc:
                    orders = await _adminOrderService.GetOrdersOrderByPaymentDescAsync();
                    break;
                case OrderSortType.StatusOrderAsc:
                    orders = await _adminOrderService.GetOrdersOrderByStatusOrderAscAsync();
                    break;
                case OrderSortType.StatusOrderDesc:
                    orders = await _adminOrderService.GetOrdersOrderByStatusOrderDescAsync();
                    break;
                case OrderSortType.TotalAsc:
                    orders = await _adminOrderService.GetOrdersOrderByTotalAscAsync();
                    break;
                case OrderSortType.TotalDesc:
                    orders = await _adminOrderService.GetOrdersOrderByTotalDescAsync();
                    break;
            }

            return View(nameof(Index), orders);
        }
    }
}
