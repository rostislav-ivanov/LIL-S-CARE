using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Home;
using LilsCareApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LilsCareApp.Infrastructure.DataConstants.AdminConstants;
namespace LilsCareApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILilsCareService _service;
        private readonly IProductsService _productService;
        private readonly IGuestService _guestService;

        public HomeController(
            ILogger<HomeController> logger,
            ILilsCareService service,
            IProductsService productService,
            IGuestService guestService)
        {
            _logger = logger;
            _service = service;
            _productService = productService;
            _guestService = guestService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.UserId = User.GetUserId();

            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddToSubscribers(HomeViewModel model)
        {
            // Clear validation errors for fields related to the MessageFromClient form
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("EmailForResponse");
            ModelState.Remove("Message");
            ModelState.Remove("PrivacyPolicyCheckBoxForMessage");
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            SubscriberDTO subscriber = new SubscriberDTO
            {
                EmailSubscriber = model.EmailSubscriber,
                AppUserId = User.GetUserId() ?? "guestUser"
            };

            await _service.AddToSubscribersAsync(subscriber);

            TempData["scrollToElementId"] = "add-to-subscribers";

            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> MessageFromClient(HomeViewModel model)
        {
            // Clear validation errors for fields related to the AddToSubscribers form
            ModelState.Remove("EmailSubscriber");
            ModelState.Remove("PrivacyPolicyCheckBox");
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            ContactUsDTO message = new ContactUsDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailForResponse = model.EmailForResponse,
                Message = model.Message,
                AppUserId = User.GetUserId() ?? "guestUser"
            };

            await _service.MessageFromClientAsync(message);

            TempData["scrollToElementId"] = "contact-as";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddRemoveWish(int productId)
        {
            await _productService.AddRemoveWishAsync(productId, User.GetUserId());

            TempData["scrollToElementId"] = "owl-carousel";

            return RedirectToAction(nameof(Index), "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            if (User.GetUserId() != null)
            {
                await _productService.AddToCartAsync(productId, User.GetUserId(), quantity);
            }
            else
            {
                _guestService.AddToCart(productId, quantity);
            }

            TempData["ShowBag"] = "show";
            TempData["scrollToElementId"] = "owl-carousel";

            return RedirectToAction(nameof(Index), "Home");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
