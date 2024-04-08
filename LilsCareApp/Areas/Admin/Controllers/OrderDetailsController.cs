using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminOrderDetails;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class OrderDetailsController : AdminController
    {
        public readonly IAdminOrderService _adminOrderService;

        public OrderDetailsController(IAdminOrderService adminOrderService)
        {
            _adminOrderService = adminOrderService;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            AdminOrderDetailsDTO order = await _adminOrderService.GetOrderDetailsAsync(id);

            return View(order);
        }

        public async Task<IActionResult> AddTrackingCode(int id, string trackingNumber)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(trackingNumber))
            {
                return BadRequest();
            }

            await _adminOrderService.AddTrackingCodeAsync(id, trackingNumber);

            return RedirectToAction(nameof(Index), new { id });
        }
    }
}
