using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ICheckoutService _checkoutService;
        private readonly IProductsService _productsService;

        public CheckoutController(
            ILogger<CheckoutController> logger,
            ICheckoutService checkoutService,
            IProductsService productsService)
        {
            _logger = logger;
            _checkoutService = checkoutService;
            _productsService = productsService;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = User.GetUserId();

            OrderDTO checkout = new OrderDTO();

            checkout.ProductsInBag = await _productsService.GetProductsInBagAsync(userId);
            checkout.ShippingProviders = await _checkoutService.GetShippingProvidersAsync();

            IDeliveryDTO delivery = await _checkoutService.GetAddressDeliveryAsync(userId);


            if (delivery.GetType() == typeof(AddressDeliveryDTO))
            {
                checkout.AddressDelivery = (AddressDeliveryDTO)delivery;
                checkout.ShippingProviderId = checkout.AddressDelivery.ShippingProviderId;
            }
            else if (delivery.GetType() == typeof(OfficeDeliveryDTO))
            {
                checkout.OfficeDelivery = (OfficeDeliveryDTO)delivery;
                checkout.ShippingProviderId = checkout.OfficeDelivery.ShippingProviderId;
            }
            else
            {
                //checkout.ShippingOffices = await _checkoutService.GetShippingOfficesAsync();
            }
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(checkout);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SelectShippingProvider(int shippingProvidersId)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.ShippingProviderId = shippingProvidersId;
            if (shippingProvidersId == 0)
            {
                checkout.AddressDelivery = new AddressDeliveryDTO();
            }
            else
            {
                checkout.OfficeDelivery = new OfficeDeliveryDTO();
                checkout.ShippingCities = await _checkoutService.GetShippingCitiesAsync(shippingProvidersId);
            }


            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }


        [AllowAnonymous]
        public IActionResult EditShippingProvider()
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.ShippingProviderId = null;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddAddressDelivery(AddressDeliveryDTO addressDelivery)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery = addressDelivery;
            if (ModelState.IsValid)
            {
                checkout.AddressDelivery.IsValid = true;
            }

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult EditAddressDelivery()
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery.IsValid = false;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }




        [AllowAnonymous]
        public async Task<IActionResult> SelectOfficeCity(string city)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.ShippingOffices = await _checkoutService.GetShippingOfficesByCityAsync(city, checkout.ShippingProviderId);
            checkout.OfficeDelivery.ShippingOffice = new ShippingOfficeDTO()
            {
                City = city,
            };
            checkout.OfficeDelivery.ShippingOffice.OfficeAddress = null;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SelectOfficeDelivery(int officeId)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.OfficeDelivery.ShippingOffice = await _checkoutService.GetShippingOfficeByIdAsync(officeId);
            //checkout.OfficeDelivery.Offices.FirstOrDefault(o => o.Id == officeId);

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddOfficeDelivery(OfficeDeliveryDTO officeDelivery)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.OfficeDelivery.FirstName = officeDelivery.FirstName;
            checkout.OfficeDelivery.LastName = officeDelivery.LastName;
            checkout.OfficeDelivery.PhoneNumber = officeDelivery.PhoneNumber;
            if (ModelState.IsValid)
            {
                checkout.OfficeDelivery.IsValid = true;
            }

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult EditOfficeDelivery()
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.OfficeDelivery.IsValid = false;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            string userId = User.GetUserId();
            await _productsService.AddToCartAsync(productId, userId, quantity);
            checkout.ProductsInBag = await _productsService.GetProductsInBagAsync(userId);
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            string userId = User.GetUserId();
            await _productsService.DeleteProductFromCartAsync(id, userId);
            checkout.ProductsInBag = await _productsService.GetProductsInBagAsync(userId);
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public async Task<IActionResult> CheckoutSummary()
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            string userId = User.GetUserId();
            await _checkoutService.CheckoutSaveAsync(checkout, userId);


            return View(nameof(Index), checkout);
        }

    }
}
