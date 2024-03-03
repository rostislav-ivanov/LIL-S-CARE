using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult MyAccount()
        {
            return View();
        }

        public IActionResult MyAddresses()
        {
            return View();
        }

        public IActionResult MyOrders()
        {
            return View();
        }

        public IActionResult MyWishes()
        {
            return View();
        }
    }
}
