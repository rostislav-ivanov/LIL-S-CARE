using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    public class TermsConditionsController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
