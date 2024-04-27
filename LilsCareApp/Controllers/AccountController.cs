using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.Products;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IProductsService _productsService;
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextManager _httpContextManager;

        public AccountController(
            IAccountService accountService,
            IProductsService productsService,
            ILogger<AccountController> logger,
            IHttpContextManager httpContextManager)
        {
            _accountService = accountService;
            _productsService = productsService;
            _logger = logger;
            _httpContextManager = httpContextManager;
        }

        // Get the user account details and send to view
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

        // Get the user account details and send to view to be updated
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

        // Update the user account details
        [HttpPost]
        public async Task<IActionResult> UpdateMyAccount(MyAddressDTO myAccount)
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

        // Get all orders of the user and send to view
        //public async Task<IActionResult> MyOrders()
        //{
        //    string userId = User.GetUserId();
        //    IEnumerable<MyOrderDTO> myOrders = await _accountService.GetMyOrdersAsync(userId);

        //    return View(myOrders);
        //}

        public async Task<IActionResult> MyWishes()
        {
            string userId = User.GetUserId();
            IEnumerable<ProductDTO> myWishes = await _productsService.GetMyWishesAsync(userId);

            return View(myWishes);
        }


        // Get all delivery addresses  of the user and send to view to be edited or deleted or set as default
        public async Task<IActionResult> MyAddresses()
        {
            string userId = User.GetUserId();
            IEnumerable<DeliveryAddressDTO> myAddresses = await _accountService.GetMyAddressesAsync(userId);

            return View(myAddresses);
        }


        // Delete the delivery address
        public async Task<IActionResult> RemoveAddress(int addressId)
        {
            var userId = User.GetUserId();
            var ownerId = await _accountService.GetAddressOwnerId(addressId);
            if (ownerId != userId)
            {
                return BadRequest();
            }
            await _accountService.RemoveAddressFromAppUserAsync(addressId);

            return RedirectToAction(nameof(MyAddresses));
        }

        // Set the default delivery address
        public async Task<IActionResult> SetDefaultAddress(int addressId)
        {
            var userId = User.GetUserId();
            var ownerId = await _accountService.GetAddressOwnerId(addressId);
            if (ownerId != userId)
            {
                return BadRequest();
            }

            if (addressId == 0)
            {
                return BadRequest();
            }

            await _accountService.SetDefaultAddressAsync(userId, addressId);

            return RedirectToAction(nameof(MyAddresses));
        }


        // Create a new delivery address and send to view to be filled
        public IActionResult AddAddress()
        {
            AddressOrderDTO model = new();

            _httpContextManager.SetSessionAddress(model);

            return View("AddEditAddress", model);
        }

        // Get an existing delivery address and send to view to be edited
        public async Task<IActionResult> EditAddress(int addressId)
        {
            var userId = User.GetUserId();
            var ownerId = await _accountService.GetAddressOwnerId(addressId);
            if (userId != ownerId)
            {
                return BadRequest();
            }

            AddressOrderDTO model = await _accountService.GetAddressDeliveryAsync(addressId);

            _httpContextManager.SetSessionAddress(model);

            return View("AddEditAddress", model);
        }


        public async Task<IActionResult> SelectDeliveryMethod(int deliveryMethodId)
        {
            AddressOrderDTO address = _httpContextManager.GetSessionAddress();
            address.DeliveryMethodId = deliveryMethodId;

            if (deliveryMethodId == 1)
            {
                address.ShippingProviders = await _accountService.GetShippingProvidersAsync();
                address.IsShippingToOffice = true;
            }

            _httpContextManager.SetSessionAddress(address);

            return View("AddEditAddress", address);
        }


        // Select the shipping provider for office delivery
        public async Task<IActionResult> SelectShippingProvider(int shippingProviderId)
        {
            var address = _httpContextManager.GetSessionAddress();

            if (address is null || address is null)
            {
                return BadRequest();
            }

            address.ShippingProviderId = shippingProviderId;
            address.ShippingProviderCities = await _accountService.GetShippingProviderCitiesAsync(shippingProviderId);
            address.ShippingProviderCity = string.Empty;
            address.ShippingOfficeId = null;

            _httpContextManager.SetSessionAddress(address);

            return View("AddEditAddress", address);
        }

        // Select the city for office delivery
        public async Task<IActionResult> SelectShippingCity(string city)
        {
            var address = _httpContextManager.GetSessionAddress();

            if (address is null || address is null)
            {
                return BadRequest();
            }

            address.ShippingProviderCity = city;
            address.ShippingOffices = await _accountService.GetShippingOfficesAsync(address.ShippingProviderId, city);
            address.ShippingOfficeId = null;

            _httpContextManager.SetSessionAddress(address);

            return View("AddEditAddress", address);
        }

        // Select the shipping office for office delivery
        public IActionResult SelectShippingOffice(int officeId)
        {
            var address = _httpContextManager.GetSessionAddress();

            if (address is null || address is null)
            {
                return BadRequest();
            }

            address.ShippingOfficeId = officeId;
            address.ShippingOffice = address.ShippingOffices.FirstOrDefault(x => x.Id == officeId);

            _httpContextManager.SetSessionAddress(address);

            return View("AddEditAddress", address);
        }


        // Add or Edit address of type delivery to office
        public async Task<IActionResult> AddOfficeDelivery(AddressOrderDTO model)
        {
            var address = _httpContextManager.GetSessionAddress();

            if (model is null || address is null)
            {
                return BadRequest();
            }

            address.FirstName = model.FirstName;
            address.LastName = model.LastName;
            address.PhoneNumber = model.PhoneNumber;

            ModelState.Remove("Country");
            ModelState.Remove("PostCode");
            ModelState.Remove("Town");
            ModelState.Remove("Address");

            if (!ModelState.IsValid || address.ShippingOffice == null)
            {
                _httpContextManager.SetSessionAddress(address);

                return View("AddEditAddress", address);
            }

            string userId = User.GetUserId();

            if (address.Id == 0)
            {
                await _accountService.AddAddressDeliveryAsync(userId, address);
            }
            else
            {
                await _accountService.EditAddressDeliveryAsync(userId, address);
            }

            return RedirectToAction(nameof(MyAddresses));
        }


        // Add or Edit address of type delivery to address
        [HttpPost]
        public async Task<IActionResult> AddAddressDelivery(AddressOrderDTO model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _httpContextManager.SetSessionAddress(model);

                return View("AddEditAddress", model);
            }

            string userId = User.GetUserId();

            if (model.Id == 0)
            {
                await _accountService.AddAddressDeliveryAsync(userId, model);
            }
            else
            {
                await _accountService.EditAddressDeliveryAsync(userId, model);
            };

            return RedirectToAction(nameof(MyAddresses));
        }


    }
}
