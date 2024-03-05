using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class ShippingReturnsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
