using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;

        }

        public async Task<IActionResult> MyAccount()
        {
            string userId = User.GetUserId();
            var myAccount = await _accountService.GetMyAccountAsync(userId);
            if (myAccount == null)
            {
                return BadRequest();
            }

            return View(myAccount);
        }

        public async Task<IActionResult> UpdateMyAccount()
        {
            string userId = User.GetUserId();
            var myAccount = await _accountService.GetMyAccountAsync(userId);
            if (myAccount == null)
            {
                return BadRequest();
            }

            return View(myAccount);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMyAccount(MyAccountDTO myAccount)
        {
            var files = Request.Form.Files.FirstOrDefault();
            if (files?.Length > 0)
            {
                // Generate a unique filename using the current date and time
                string fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Path.GetFileName(files.FileName)}";
                var filePath = Path.Combine("files", "accounts", fileName);
                var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

                // Save the file to the server
                using (var stream = new FileStream(uploadDirectory, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }

                myAccount.ImagePath = ("\\" + filePath);
            }

            if (!ModelState.IsValid)
            {
                return View(myAccount);
            }

            string userId = User.GetUserId();
            await _accountService.UpdateMyAccountAsync(userId, myAccount);

            return RedirectToAction(nameof(MyAccount));
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
