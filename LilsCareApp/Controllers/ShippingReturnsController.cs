using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class ShippingReturnsController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
