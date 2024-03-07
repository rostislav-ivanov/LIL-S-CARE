using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ILilsCareService _service;

        public ProductsController(ILilsCareService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(id);
        }

        public async Task<IActionResult> AddToWish(int id)
        {
            string userId = User.GetUserId();

            await _service.AddToWishAsync(id, userId);

            TempData["scrollToElementId"] = "owl-carousel";

            return View("Index");
        }

        public async Task<IActionResult> RemoveFromWish(int id)
        {
            string userId = User.GetUserId();

            await _service.RemoveFromWishAsync(id, userId);

            TempData["scrollToElementId"] = "owl-carousel";

            return View("Index");
        }

        public async Task<IActionResult> AddToCart(int id)
        {

            string userId = User.GetUserId();

            await _service.AddToCartAsync(id, userId);

            return View("Index");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = User.GetUserId();

            await _service.RemoveFromCartAsync(id, userId);

            return View("Index");
        }

    }
}
