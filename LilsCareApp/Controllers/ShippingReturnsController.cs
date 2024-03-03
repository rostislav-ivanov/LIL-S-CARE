using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class ShippingReturnsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
