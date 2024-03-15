using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace LilsCareApp.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IProductsService _service;

        public CheckoutController(ILogger<CheckoutController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = User.GetUserId();
            CheckoutDTO checkout = new CheckoutDTO();
            checkout.ShippingProviders = await _service.GetAllShippingProvidersAsync();
            checkout.ProductsInBag = await _service.GetProductsInBagAsync(userId);

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));
            return View(checkout);
        }

        [AllowAnonymous]
        public IActionResult SelectShippingProvider(int shippingProviderId)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.ShippingProvider = checkout.ShippingProviders.FirstOrDefault(sp => sp.Id == shippingProviderId);
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult EditShippingProvider()
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.ShippingProvider = null;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            string userId = User.GetUserId();
            await _service.AddToCartAsync(productId, userId, quantity);
            checkout.ProductsInBag = await _service.GetProductsInBagAsync(userId);
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            string userId = User.GetUserId();
            await _service.DeleteProductFromCartAsync(id, userId);
            checkout.ProductsInBag = await _service.GetProductsInBagAsync(userId);
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddressDeliveryToOffice(AddressDeliveryDTO addressDelivery)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery = addressDelivery;
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), checkout);
            }
            checkout.AddressDelivery = addressDelivery;

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddressDeliveryToAddress(AddressDeliveryDTO addressDelivery)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery = addressDelivery;
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), checkout);
            }
            checkout.AddressDelivery = addressDelivery;

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult EditAddressDelivery()
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery = null;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

    }
}
