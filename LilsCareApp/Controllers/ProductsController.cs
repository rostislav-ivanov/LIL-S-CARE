using LilsCareApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ILilsCareService _service;

        public ProductsController(ILilsCareService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(id);
        }

        public async Task<IActionResult> AddToWish(int id)
        {
            string userId = User.GetUserId();

            await _service.AddToWishAsync(id, userId);

            string referringUrl = Request.Headers["Referer"].ToString();

            // Redirect to Index with a query parameter indicating the element to scroll to
            ViewData["scrollToElement"] = "owl-carousel";
            return Redirect(referringUrl);
        }

        public async Task<IActionResult> RemoveFromWish(int id)
        {
            string userId = User.GetUserId();

            await _service.RemoveFromWishAsync(id, userId);

            string referringUrl = Request.Headers["Referer"].ToString();

            // Redirect to Index with a query parameter indicating the element to scroll to
            ViewData["scrollToElement"] = "owl-carousel";
            return Redirect(referringUrl);
        }
    }
}
