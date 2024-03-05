using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Components
{
    public class ShoppingBagComponent : ViewComponent
    {
        private readonly ILilsCareService _service;
        private readonly HttpContext _httpContext;


        public ShoppingBagComponent(ILilsCareService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? userId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            userId ??= "guestUser";
            var productsInBag = await _service.GetProductsInBagAsync(userId);
            ViewBag.Total = productsInBag.Sum(p => p.Quantity * p.Price);
            return await Task.FromResult((IViewComponentResult)View(productsInBag));
        }

    }
}

