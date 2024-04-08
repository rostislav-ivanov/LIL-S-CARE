using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LilsCareApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
