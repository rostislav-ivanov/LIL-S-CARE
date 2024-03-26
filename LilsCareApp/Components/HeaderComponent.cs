using LilsCareApp.Core.Contracts;
using LilsCareApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IProductsService _productsService;
        private readonly IAccountService _accountService;
        private readonly IGuestService _guestService;


        public HeaderComponent(IProductsService productsService, IAccountService accountService, IGuestService guestService)
        {
            _productsService = productsService;
            _accountService = accountService;
            _guestService = guestService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                ViewBag.Count = await _productsService.GetCountInBagAsync(userId);
                ViewBag.UserImagePath = await _accountService.GetUserImagePathAsync(userId);
            }
            else
            {
                ViewBag.Count = _guestService.GetCountInBag();
            }

            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
