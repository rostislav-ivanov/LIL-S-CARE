using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using LilsCareApp.Core.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IProductsService _productsService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, IProductsService productsService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _productsService = productsService;
            _logger = logger;

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
        public async Task<IActionResult> MyOrders()
        {
            string userId = User.GetUserId();
            IEnumerable<MyOrderDTO> myOrders = await _accountService.GetMyOrdersAsync(userId);

            return View(myOrders);
        }

        public async Task<IActionResult> MyWishes()
        {
            string userId = User.GetUserId();
            IEnumerable<ProductDTO> myWishes = await _productsService.GetMyWishesAsync(userId);

            return View(myWishes);
        }

        public async Task<IActionResult> AddToCart(int productId)
        {

            string userId = User.GetUserId();

            await _productsService.AddToCartAsync(productId, userId, 1);

            TempData["ShowBag"] = "show";

            return RedirectToAction(nameof(MyWishes), "Account");
        }

        public async Task<IActionResult> AddRemoveWish(int productId)
        {
            string userId = User.GetUserId();

            await _productsService.AddRemoveWishAsync(productId, userId);

            return RedirectToAction(nameof(MyWishes), "Account");
        }



        // Get all delivery addresses  of the user and send to view to be edited or deleted or set as default
        public async Task<IActionResult> MyAddresses()
        {
            string userId = User.GetUserId();
            IEnumerable<DeliveryAddressDTO> myAddresses = await _accountService.GetMyAddressesAsync(userId);

            return View(myAddresses);
        }


        // Delete the delivery address
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            if (addressId == 0)
            {
                return BadRequest();
            }
            await _accountService.DeleteAddressAsync(addressId);

            return RedirectToAction(nameof(MyAddresses));
        }

        // Set the default delivery address
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


        // Create a new delivery address and send to view to be filled
        public IActionResult AddAddress()
        {
            DeliveryAddressesDTO model = new();

            HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

            return View("AddEditAddress", model);
        }

        // Get an existing delivery address and send to view to be edited
        public async Task<IActionResult> EditAddress(int addressId)
        {
            if (addressId == 0)
            {
                return BadRequest();
            }

            DeliveryAddressesDTO model = await _accountService.GetAddressDeliveryAsync(addressId);

            HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

            return View("AddEditAddress", model);
        }


        // Select the delivery type of address (office or address)
        public async Task<IActionResult> SelectDeliveryType(bool isShippingToOffice)
        {
            DeliveryAddressesDTO model = JsonConvert.DeserializeObject<DeliveryAddressesDTO>(HttpContext.Session.GetString("AddressDelivery"));
            if (model == null)
            {
                model = new DeliveryAddressesDTO();
            }
            else if (isShippingToOffice)
            {
                model.Address = null;
                model.Office = new OfficeDTO()
                {
                    ShippingProviders = await _accountService.GetShippingProvidersAsync(),
                };
            }
            else
            {
                model.Office = null;
                model.Address = new AddressDTO();
            }

            HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

            return View("AddEditAddress", model);
        }


        // Select the shipping provider for office delivery
        public async Task<IActionResult> SelectShippingProvider(int shippingProviderId)
        {
            DeliveryAddressesDTO model = JsonConvert.DeserializeObject<DeliveryAddressesDTO>(HttpContext.Session.GetString("AddressDelivery"));

            model.Office.ShippingProviderId = shippingProviderId;
            model.Office.ShippingProviderCities = await _accountService.GetShippingProviderCitiesAsync(shippingProviderId);
            model.Office.CityName = null;
            model.Office.ShippingOfficeId = null;

            HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

            return View("AddEditAddress", model);
        }


        // Select the city for office delivery
        public async Task<IActionResult> SelectShippingCity(string city)
        {
            DeliveryAddressesDTO model = JsonConvert.DeserializeObject<DeliveryAddressesDTO>(HttpContext.Session.GetString("AddressDelivery"));

            model.Office.CityName = city;
            model.Office.ShippingOffices = await _accountService.GetShippingOfficesAsync(model.Office.ShippingProviderId, city);
            model.Office.ShippingOfficeId = null;

            HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

            return View("AddEditAddress", model);
        }

        // Select the shipping office for office delivery
        public IActionResult SelectShippingOffice(int officeId)
        {
            DeliveryAddressesDTO model = JsonConvert.DeserializeObject<DeliveryAddressesDTO>(HttpContext.Session.GetString("AddressDelivery"));

            model.Office.ShippingOfficeId = officeId;

            HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

            return View("AddEditAddress", model);
        }


        // Add or Edit address of type delivery to office
        public async Task<IActionResult> AddOfficeDelivery(OfficeDTO officeDTO)
        {
            DeliveryAddressesDTO model = JsonConvert.DeserializeObject<DeliveryAddressesDTO>(HttpContext.Session.GetString("AddressDelivery"));

            model.Office.FirstName = officeDTO.FirstName;
            model.Office.LastName = officeDTO.LastName;
            model.Office.PhoneNumber = officeDTO.PhoneNumber;

            if (!ModelState.IsValid || !model.Office.IsSelectedOffice())
            {
                HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

                return View("AddEditAddress", model);
            }

            string userId = User.GetUserId();

            if (model.Office.Id == 0)
            {
                await _accountService.AddOfficeDeliveryAsync(userId, model.Office);
            }
            else
            {
                await _accountService.EditOfficeDeliveryAsync(userId, model.Office);
            }

            return RedirectToAction(nameof(MyAddresses));
        }


        // Add or Edit address of type delivery to address
        [HttpPost]
        public async Task<IActionResult> AddAddressDelivery(AddressDTO addressDTO)
        {
            DeliveryAddressesDTO model = JsonConvert.DeserializeObject<DeliveryAddressesDTO>(HttpContext.Session.GetString("AddressDelivery"));

            model.Address = addressDTO;

            if (addressDTO is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                HttpContext.Session.SetString("AddressDelivery", JsonConvert.SerializeObject(model));

                return View("AddEditAddress", model);
            }

            string userId = User.GetUserId();

            if (model.Address.Id == 0)
            {
                await _accountService.AddAddressDeliveryAsync(userId, model.Address);
            }
            else
            {
                await _accountService.EditAddressDeliveryAsync(userId, model.Address);
            };

            return RedirectToAction(nameof(MyAddresses));
        }


    }
}
