using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

namespace LilsCareApp.Controllers
{
    public class CartController : BaseController
    {
        private readonly ILogger<CartController> _logger;
        private readonly IProductsService _service;

        public CartController(ILogger<CartController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int shippingProviderId)
        {
            string userId = User.GetUserId();
            userId ??= "guestUser";
            CartDTO model = await _service.GetProductsInCartAsync(userId);
            if (model.Products.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            model.ShippingProviderId = shippingProviderId;
            model.SubTotal = model.Products.Sum(p => p.Sum);
            if (model.SubTotal >= FreeShipping)
            {
                model.ShippingPrice = 0;
            }
            //else
            //{
            //    model.ShippingPrice = model.ShippingProviders.FirstOrDefault(sp => sp.Id == model.ShippingProviderId)?.Price ?? 0;
            //}
            model.Total = model.SubTotal + model.ShippingPrice;
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {

            string userId = User.GetUserId();


            await _service.AddToCartAsync(productId, userId, quantity);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            string userId = User.GetUserId();

            await _service.DeleteProductFromCartAsync(id, userId);

            return RedirectToAction("Index");
        }

    }
}
