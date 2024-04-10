using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Details;
using LilsCareApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Review;

namespace LilsCareApp.Controllers
{

    public class DetailsController : BaseController
    {
        private readonly IDetailsService _service;
        private readonly IProductsService _productService;
        private readonly IGuestService _guestService;
        public DetailsController(IDetailsService service, IProductsService productService, IGuestService guestService)
        {
            _service = service;
            _productService = productService;
            _guestService = guestService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int id)
        {
            string userId = User.GetUserId();
            DetailsDTO details = await _service.GetDetailsByIdAsync(id, userId);
            if (details == null)
            {
                return NotFound();
            }

            ViewBag.UserId = userId;

            return View(details);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            if (User.GetUserId() != null)
            {
                await _productService.AddToCartAsync(productId, User.GetUserId(), quantity);
            }
            else
            {
                _guestService.AddToCart(productId, quantity);
            }

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(Index), "Details", new { id = productId });
        }

        public async Task<IActionResult> AddRemoveWish(int productId)
        {
            string userId = User.GetUserId();

            await _productService.AddRemoveWishAsync(productId, userId);

            return RedirectToAction(nameof(Index), "Details", new { id = productId });
        }

        public async Task<IActionResult> AddReview(int productId)
        {
            string userId = User.GetUserId();

            AddReviewDTO? review = await _service.GetReviewAsync(productId, userId);
            if (review == null)
            {
                return BadRequest();
            }

            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewDTO review)
        {
            review.Rating = review.Stars.Count(s => s);

            if (review.Rating < RatingMinValue || review.Rating > RatingMaxValue)
            {
                ModelState.AddModelError(nameof(review.Rating), RequireRating);
                return View(review);
            }

            ModelState.Remove(nameof(review.Rating));

            if (!ModelState.IsValid)
            {
                return View(review);
            }

            long size = 0;
            var files = Request.Form.Files;
            int i = 0;
            foreach (var formFile in files)
            {

                if (formFile.Length > 0)
                {
                    // Generate a unique filename using the current date and time
                    string fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Path.GetFileName(formFile.FileName)}";
                    var filePath = Path.Combine("files", "reviews", fileName);
                    var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

                    using (var stream = new FileStream(uploadDirectory, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    size += formFile.Length;
                    review.Images[i++].ImagePath = ("\\" + filePath);
                }
            }
            review.AuthorId = User.GetUserId();
            await _service.SaveReviewAsync(review);

            return RedirectToAction(nameof(Index), "Details", new { id = review.ProductId });
        }

    }
}
