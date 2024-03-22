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

        public async Task<IActionResult> MyAddresses()
        {
            string userId = User.GetUserId();
            IEnumerable<MyAddressDTO> myAddresses = await _accountService.GetMyAddressesAsync(userId);

            return View(myAddresses);
        }

        public async Task<IActionResult> AddAddress(int addressId)
        {
            if (addressId == 0)
            {
                return View(new AddressDTO());
            }
            var model = await _accountService.GetAddressAsync(addressId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.GetUserId();
            if (model.Id != 0) // Update the address
            {
                await _accountService.UpdateAddressAsync(userId, model);
            }
            else // Add a new address
            {
                await _accountService.AddAddressAsync(userId, model);
            }

            return RedirectToAction(nameof(MyAddresses));
        }

        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            if (addressId == 0)
            {
                return BadRequest();
            }
            await _accountService.DeleteAddressAsync(addressId);

            return RedirectToAction(nameof(MyAddresses));
        }

        public async Task<IActionResult> SetDefaultAddress(int addressId)
        {
            if (addressId == 0)
            {
                return BadRequest();
            }
            string userId = User.GetUserId();
            await _accountService.SetDefaultAddressAsync(userId, addressId);

            return RedirectToAction(nameof(MyAddresses));
        }

        public async Task<IActionResult> AddOffice(int addressId)
        {
            if (addressId == 0)
            {
                return View(new OfficeDTO());
            }
            OfficeDTO model = await _accountService.GetOfficeAsync(addressId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOffice(OfficeDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.GetUserId();
            if (model.Id != 0) // Update the address
            {
                await _accountService.UpdateOfficeAsync(userId, model);
            }
            else // Add a new address
            {
                //await _accountService.AddOfficeAsync(userId, model);
            }

            return RedirectToAction(nameof(MyAddresses));
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
