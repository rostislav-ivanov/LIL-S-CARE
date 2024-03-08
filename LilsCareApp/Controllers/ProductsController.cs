using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id = 0)
        {
            string userId = User.GetUserId();
            ProductsDTO products = new ProductsDTO
            {
                Products = id == 0
                    ? await _service.GetAllAsync(userId)
                    : await _service.GetByCategoryAsync(id, userId),
                Categories = await _service.GetCategoriesAsync(),
            };
            products.Categories.Add(new CategoryDTO { Id = 0, Name = "Всички" });

            ViewBag.CheckedId = id;

            return View(products);
        }

        public async Task<IActionResult> AddToWish(int id)
        {
            string userId = User.GetUserId();

            await _service.AddToWishAsync(id, userId);

            TempData["scrollToElementId"] = "owl-carousel";

            return RedirectToAction(nameof(Index), "Products");
        }

        public async Task<IActionResult> RemoveFromWish(int id)
        {
            string userId = User.GetUserId();

            await _service.RemoveFromWishAsync(id, userId);

            TempData["scrollToElementId"] = "owl-carousel";

            return RedirectToAction(nameof(Index), "Products");
        }

        public async Task<IActionResult> AddToCart(int id)
        {

            string userId = User.GetUserId();

            await _service.AddToCartAsync(id, userId);

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = User.GetUserId();

            await _service.RemoveFromCartAsync(id, userId);

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }

        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            string userId = User.GetUserId();

            await _service.DeleteProductFromCartAsync(id, userId);

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }


    }
}
