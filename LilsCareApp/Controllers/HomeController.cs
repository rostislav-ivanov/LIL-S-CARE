using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Core.Models.GuestUser;
using LilsCareApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

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

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.UserId = User.GetUserId();

            if (HttpContext.Session.GetString(GuestSession) == null)
            {
                GuestOrder order = new() { sessionId = HttpContext.Session.Id };

                HttpContext.Session.SetString(GuestSession, JsonConvert.SerializeObject(order));
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
