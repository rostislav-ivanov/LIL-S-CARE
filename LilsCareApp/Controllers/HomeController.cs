using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILilsCareService _service;

        public HomeController(ILogger<HomeController> logger, ILilsCareService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            ViewBag.UserId = User.GetUserId();
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
                Email = model.EmailSubscriber,
                AppUserId = User.GetUserId() ?? "guestUser"
            };

            await _service.AddToSubscribersAsync(subscriber);

            // Redirect to Index with a query parameter indicating the element to scroll to
            ViewData["scrollToElement"] = "add-to-subscribers";
            return View("Index");
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

            MessageFromClientDTO message = new MessageFromClientDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailForResponse = model.EmailForResponse,
                Message = model.Message,
                AppUserId = User.GetUserId() ?? "guestUser"
            };

            await _service.MessageFromClientAsync(message);

            // Redirect to Index with a query parameter indicating the element to scroll to
            ViewData["scrollToElement"] = "contact-as";
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
