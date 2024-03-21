using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IProductsService _productsService;
        private readonly IAccountService _accountService;

        private readonly HttpContext _httpContext;


        public HeaderComponent(IProductsService productsService, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _productsService = productsService;
            _accountService = accountService;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? userId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Count = userId != null ? await _productsService.GetCountInBagAsync(userId) : 0;
            ViewBag.UserImagePath = userId != null ? await _accountService.GetUserImagePathAsync(userId) : null;
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
