using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
