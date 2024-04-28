using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Header;
using LilsCareApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace LilsCareApp.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly IProductsService _productsService;
        private readonly IAccountService _accountService;
        private readonly IGuestService _guestService;
        private readonly IOptions<RequestLocalizationOptions> _requestLocalizationOptions;


        public HeaderComponent(
            IProductsService productsService,
            IAccountService accountService,
            IGuestService guestService,
            IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _productsService = productsService;
            _accountService = accountService;
            _guestService = guestService;
            _requestLocalizationOptions = requestLocalizationOptions;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            HeaderComponentViewModel model = new();

            if (userId != null)
            {
                model.CountInBag = await _productsService.GetCountInBagAsync(userId);
                model.UserImagePath = await _accountService.GetUserImagePathAsync(userId);
            }
            else
            {
                model.CountInBag = _guestService.GetCountInBag();
            }

            if (_requestLocalizationOptions?.Value?.DefaultRequestCulture != null)
            {
                model.Cultures = _requestLocalizationOptions.Value.SupportedUICultures
                    .ToDictionary(c => c.Name.ToUpper(), c => char.ToUpper(c.NativeName[0]) + c.NativeName.Substring(1));
            }

            model.ReturnUrl = string.IsNullOrEmpty(Request.Path) ? "~/" : $"~{Request.Path.Value}";
            if (!string.IsNullOrEmpty(Request.QueryString.Value))
            {
                // Append the query string parameters to the redirect URL
                model.ReturnUrl += Request.QueryString.Value;
            }

            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
}
