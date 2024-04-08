using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class OrderDetailsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
