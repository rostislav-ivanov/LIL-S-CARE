using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.GuestUser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

namespace LilsCareApp.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IProductsService _productsService;
        private readonly IAccountService _accountService;


        public HeaderComponent(IProductsService productsService, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _productsService = productsService;
            _accountService = accountService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                ViewBag.Count = await _productsService.GetCountInBagAsync(userId);
                ViewBag.UserImagePath = await _accountService.GetUserImagePathAsync(userId);
            }
            else if (HttpContext.Session.GetString(GuestSession) != null)
            {
                var order = JsonConvert.DeserializeObject<GuestOrder>(HttpContext.Session.GetString(GuestSession));
                ViewBag.Count = order.GuestBags.Sum(gb => gb.Quantity);
            }
            else
            {
                ViewBag.Count = 0;
            }

            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
