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
            checkout.AddressDelivery = await _checkoutService.GetAddressDeliveryAsync(userId);
            checkout.ShippingProviders = await _checkoutService.GetShippingProvidersAsync();
            checkout.PromoCodes = await _checkoutService.GetPromoCodesAsync(userId);
            if (checkout.AddressDelivery != null)
            {
                checkout.ShippingProviderId = checkout.AddressDelivery.IsShippingToOffice
                    ? checkout.AddressDelivery.ShippingOffice.ShippingProviderId : 0;
            }

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(checkout);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SelectShippingProvider(int shippingProvidersId)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));

            if (!checkout.ShippingProviders.Any(sp => sp.Id == shippingProvidersId))
            {
                return BadRequest();
            }
            checkout.ShippingProviderId = shippingProvidersId;
            checkout.AddressDelivery = new AddressDeliveryDTO();
            checkout.AddressDelivery.IsShippingToOffice = shippingProvidersId != 0;
            if (checkout.IsDeliveryToOffice())
            {
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
            checkout.AddressDelivery = null;

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
            checkout.AddressDelivery.ShippingOffice = new ShippingOfficeDTO()
            {
                City = city,
            };

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SelectOfficeDelivery(int officeId)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery.ShippingOffice = checkout.ShippingOffices.FirstOrDefault(so => so.Id == officeId);

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddOfficeDelivery(AddressDeliveryDTO addressDelivery)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery.FirstName = addressDelivery.FirstName;
            checkout.AddressDelivery.LastName = addressDelivery.LastName;
            checkout.AddressDelivery.PhoneNumber = addressDelivery.PhoneNumber;
            ModelState.Remove("addressDelivery.Country");
            ModelState.Remove("addressDelivery.PostCode");
            ModelState.Remove("addressDelivery.Town");
            ModelState.Remove("addressDelivery.Address");

            if (ModelState.IsValid)
            {
                checkout.AddressDelivery.IsValid = true;
            }

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult EditOfficeDelivery()
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery.IsValid = false;
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
        public async Task<IActionResult> DiscountWithPromoCode(int? promoCodeId)
        {
            OrderDTO checkout = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Checkout"));

            checkout.PromoCodeId = promoCodeId;

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
            string orderSNumber = await _checkoutService.CheckoutSaveAsync(checkout, userId);
            OrderSummaryDTO orderSummary = await _checkoutService.OrderSummaryAsync(orderSNumber);

            return View(orderSummary);
        }

    }
}
