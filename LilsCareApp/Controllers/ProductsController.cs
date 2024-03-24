using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
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

        //public async Task<IActionResult> AddToWish(int productId)
        //{
        //    string userId = User.GetUserId();

        //    await _service.AddToWishAsync(productId, userId);

        //    TempData["scrollToElementId"] = "owl-carousel";

        //    return RedirectToAction(nameof(Index), "Products");
        //}

        //public async Task<IActionResult> RemoveFromWish(int productId)
        //{
        //    string userId = User.GetUserId();

        //    await _service.RemoveFromWishAsync(productId, userId);

        //    TempData["scrollToElementId"] = "owl-carousel";

        //    return RedirectToAction(nameof(Index), "Products");
        //}

        public async Task<IActionResult> AddRemoveWish(int productId)
        {
            string userId = User.GetUserId();

            await _service.AddRemoveWishAsync(productId, userId);

            TempData["scrollToElementId"] = "owl-carousel";

            return RedirectToAction(nameof(Index), "Products");
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {

            string userId = User.GetUserId();

            await _service.AddToCartAsync(productId, userId, quantity);

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }

        [AllowAnonymous]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            string userId = User.GetUserId();

            await _service.DeleteProductFromCartAsync(id, userId);

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }


    }
}
