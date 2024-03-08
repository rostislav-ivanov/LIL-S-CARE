using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class DetailsController : BaseController
    {
        private readonly IDetailsService _service;
        public DetailsController(IDetailsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            string userId = User.GetUserId();
            DetailsDTO details = await _service.GetDetailsById(id, userId);
            if (details == null)
            {
                return NotFound();
            }

            if (details.Images is null)
            {
                details.Images = new List<ImageDTO>()
                    { new ImageDTO {ImagePath= "https://via.placeholder.com/150"} };
            }

            return View(details);
        }




    }
}
