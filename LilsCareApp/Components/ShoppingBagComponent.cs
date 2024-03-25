using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Core.Models.GuestUser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

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
            IEnumerable<ProductsInBagDTO> productsInBag = new List<ProductsInBagDTO>();

            string? userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                productsInBag = await _productService.GetProductsInBagAsync(userId);

            }
            else if (HttpContext.Session.GetString(GuestSession) != null)
            {
                GuestOrder order = JsonConvert.DeserializeObject<GuestOrder>(HttpContext.Session.GetString(GuestSession));

                productsInBag = await _guestService.GetProductsInBagAsync(order.GuestBags);
            }
            ViewBag.Total = productsInBag.Sum(p => p.Quantity * p.Price);
            return await Task.FromResult((IViewComponentResult)View(productsInBag));
        }

    }
}

