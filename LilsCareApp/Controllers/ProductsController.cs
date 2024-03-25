using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Core.Models.GuestUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

namespace LilsCareApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productService;
        private readonly IGuestService _guestService;
        private ISession _session => HttpContext.Session;

        public ProductsController(IProductsService productService, IGuestService guestService)
        {
            _productService = productService;
            _guestService = guestService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int id = 0)
        {
            string userId = User.GetUserId();
            ProductsDTO products = new ProductsDTO
            {
                Products = id == 0
                    ? await _productService.GetAllAsync(userId)
                    : await _productService.GetByCategoryAsync(id, userId),
                Categories = await _productService.GetCategoriesAsync(),
            };
            products.Categories.Add(new CategoryDTO { Id = 0, Name = "Всички" });

            ViewBag.CheckedId = id;

            return View(products);
        }

        public async Task<IActionResult> AddRemoveWish(int productId)
        {
            string userId = User.GetUserId();

            await _productService.AddRemoveWishAsync(productId, userId);

            TempData["scrollToElementId"] = "owl-carousel";

            return RedirectToAction(nameof(Index), "Products");
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            if (await _productService.IsProductAsync(productId) == false)
            {
                return BadRequest();
            }

            string userId = User.GetUserId();

            if (userId != null)
            {
                await _productService.AddToCartAsync(productId, userId, quantity);
            }
            else if (_session.GetString(GuestSession) != null)
            {
                var order = JsonConvert.DeserializeObject<GuestOrder>(_session.GetString(GuestSession));



                var bag = order.GuestBags.FirstOrDefault(b => b.ProductId == productId);
                if (bag == null)
                {
                    order.GuestBags.Add(new GuestBag()
                    {
                        ProductId = productId,
                        Quantity = quantity
                    });
                }
                else if (bag.Quantity + quantity >= 1) // quantity must be at least 1
                {
                    bag.Quantity += quantity;
                }


                _session.SetString(GuestSession, JsonConvert.SerializeObject(order));
            }

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }

        [AllowAnonymous]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            string userId = User.GetUserId();

            if (userId != null)
            {
                await _productService.DeleteProductFromCartAsync(id, userId);
            }
            else if (_session.GetString(GuestSession) != null)
            {
                var order = JsonConvert.DeserializeObject<GuestOrder>(_session.GetString(GuestSession));

                order.GuestBags.RemoveAll(b => b.ProductId == id);

                _session.SetString(GuestSession, JsonConvert.SerializeObject(order));
            }

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Products");
        }


    }
}
