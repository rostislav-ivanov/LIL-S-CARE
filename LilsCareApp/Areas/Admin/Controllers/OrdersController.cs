using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class OrdersController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
