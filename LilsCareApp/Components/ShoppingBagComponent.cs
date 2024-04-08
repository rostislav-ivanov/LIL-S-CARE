using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Components
{
    public class ShoppingBagComponent : ViewComponent
    {
        private readonly IProductsService _productService;
        private readonly IGuestService _guestService;

        public ShoppingBagComponent(IProductsService productService, IGuestService guestService)
        {
            _productService = productService;
            _guestService = guestService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<ProductsInBagDTO> productsInBag = [];

            string? userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                productsInBag = await _productService.GetProductsInBagAsync(userId);
            }
            else
            {
                productsInBag = await _guestService.GetProductsInBagAsync();
            }
            ViewBag.Total = productsInBag.Sum(p => p.Quantity * p.Price);
            return await Task.FromResult((IViewComponentResult)View(productsInBag));
        }

    }
}

