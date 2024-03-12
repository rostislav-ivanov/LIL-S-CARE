using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class IngredientsController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILilsCareService _service;

        public IngredientsController(ILogger<HomeController> logger, ILilsCareService service)
        {
            _logger = logger;
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.UserId = User.GetUserId();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddToSubscribers(SubscriberDTO subscriber)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            subscriber.AppUserId = User.GetUserId() ?? "guestUser";

            await _service.AddToSubscribersAsync(subscriber);

            TempData["scrollToElementId"] = "add-to-subscribers";

            return RedirectToAction("Index");
        }
    }
}
