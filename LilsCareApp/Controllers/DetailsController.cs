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

            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> AddReview(int productId)
        {
            string userId = User.GetUserId();
            DetailsDTO details = await _service.GetDetailsById(productId, userId);
            var review = new AddReviewDTO
            {
                ProductId = details.Id,
                ProductName = details.Name,
                ProductImage = details.Images[0].ImagePath,
                AuthorId = User.GetUserId(),
                AuthorName = User.GetUserName(),
                Email = User.GetUserEmail(),
            };
            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewDTO review)
        {
            long size = 0;
            var files = Request.Form.Files;
            review.Images = new List<string>();  // Create a list of ImageDTO objects

            foreach (var formFile in files)
            {

                if (formFile.Length > 0)
                {
                    // Generate a unique filename using the current date and time
                    string fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Path.GetFileName(formFile.FileName)}";
                    var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "reviews");
                    var filePath = Path.Combine(uploadDirectory, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    size += formFile.Length;
                    review.Images.Add(filePath);
                }
            }
            review.AuthorId = User.GetUserId();
            await _service.AddReviewAsync(review);

            return RedirectToAction(nameof(Index), "Details", new { id = review.ProductId });
        }

    }
}
