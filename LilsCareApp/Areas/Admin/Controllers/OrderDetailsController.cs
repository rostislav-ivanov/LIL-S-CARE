using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class OrderDetailsController : AdminController
    {
        public readonly IAdminOrderService _adminOrderService;
        public readonly IAdminOrderDetailsService _adminOrderDetailsService;

        public OrderDetailsController(IAdminOrderService adminOrderService, IAdminOrderDetailsService adminOrderDetailsService)
        {
            _adminOrderService = adminOrderService;
            _adminOrderDetailsService = adminOrderDetailsService;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            AdminOrderDetailsDTO order = await _adminOrderDetailsService.GetOrderDetailsAsync(id);
            order.StatusesOrder = await _adminOrderService.GetStatusesOrderAsync();
            order.Products = await _adminOrderDetailsService.GetProductsNameAsync();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrackingCode(int id, string trackingNumber)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(trackingNumber))
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.AddTrackingCodeAsync(id, trackingNumber);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> ChangeStatus(int id, int statusId)
        {
            if (id == 0 || statusId == 0)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.ChangeStatusAsync(id, statusId);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> ChangePayment(int id, bool? isPaid)
        {
            if (id == 0 || isPaid == null)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.ChangePaymentAsync(id, isPaid);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> AddProductToOrder(int id, int productId)
        {
            if (id == 0 || productId == 0)
        {
                return BadRequest();
            }

            await _adminOrderDetailsService.AddProductToOrderAsync(id, productId);

            return RedirectToAction(nameof(Index), new { id });
        }
    }
}
