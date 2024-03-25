using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;
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
        private readonly IAccountService _accountService;

        public CheckoutController(
            ILogger<CheckoutController> logger,
            ICheckoutService checkoutService,
            IProductsService productsService,
            IAccountService accountService)
        {
            _logger = logger;
            _checkoutService = checkoutService;
            _productsService = productsService;
            _accountService = accountService;
        }

        // GET: CheckoutController
        // Display the order summary page with all the necessary information for the order
        public async Task<IActionResult> Index()
        {
            string userId = User.GetUserId();


            OrderDTO order = new OrderDTO()
            {
                ProductsInBag = await _productsService.GetProductsInBagAsync(userId),
                PromoCodes = await _checkoutService.GetPromoCodesAsync(userId),
                PaymentMethods = await _checkoutService.GetPaymentMethodsAsync(),
            };

            int? defaultAddressId = await _checkoutService.GetDefaultAddressIdAsync(userId);

            if (defaultAddressId != null)
            {
                var defaultAddress = await _accountService.GetAddressDeliveryAsync(defaultAddressId.Value);
                if (defaultAddress.DeliveryType() == defaultAddress.OfficeDeliveryType)
                {
                    order.Office = defaultAddress.Office;
                    order.IsValidOrder = true;
                }
                else if (defaultAddress.DeliveryType() == defaultAddress.AddressDeliveryType)
                {
                    order.Address = defaultAddress.Address;
                    order.IsValidOrder = true;
                }
            }

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(order);
        }



        // Select the delivery type of address (office or address).
        // If the delivery type is office, get the shipping provider.
        public async Task<IActionResult> SelectDeliveryType(bool isShippingToOffice)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            if (isShippingToOffice)
            {
                order.Address = null;
                order.Office ??= new OfficeDTO()
                {
                    ShippingProviders = await _accountService.GetShippingProvidersAsync()
                };
                order.Office.Id = 0;
            }
            else
            {
                order.Office = null;
                order.Address ??= new AddressDTO();
                order.Address.Id = 0;
            }
            order.IsValidOrder = false;

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }

        // Select the shipping provider for office delivery
        // Get the cities for the selected shipping provider.
        public async Task<IActionResult> SelectShippingProvider(int shippingProviderId)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            order.Office.ShippingProviderId = shippingProviderId;
            order.Office.ShippingProviderCities = await _accountService.GetShippingProviderCitiesAsync(shippingProviderId);
            order.Office.CityName = null;
            order.Office.ShippingOfficeId = null;

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }


        // Select the city for office delivery
        // Get the shipping offices for the selected city.
        public async Task<IActionResult> SelectShippingCity(string city)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            order.Office.CityName = city;
            order.Office.ShippingOffices = await _accountService.GetShippingOfficesAsync(order.Office.ShippingProviderId, city);
            order.Office.ShippingOfficeId = null;

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }

        // Select the shipping office for office delivery
        public IActionResult SelectShippingOffice(int officeId)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            order.Office.ShippingOfficeId = officeId;

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }

        // Add or Edit address of type delivery to office
        public async Task<IActionResult> AddOfficeDelivery(OfficeDTO officeDTO)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            order!.Office!.FirstName = officeDTO.FirstName;
            order.Office.LastName = officeDTO.LastName;
            order.Office.PhoneNumber = officeDTO.PhoneNumber;

            if (ModelState.IsValid && order.Office.IsSelectedOffice())
            {
                order.IsValidOrder = true;
            }

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }


        // Add or Edit address of type delivery to address
        [HttpPost]
        public async Task<IActionResult> AddAddressDelivery(AddressDTO addressDTO)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            order.Address = addressDTO;

            if (addressDTO is null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                order.IsValidOrder = true;
            }

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }


        // Select the payment method for the order.
        public async Task<IActionResult> DiscountWithPromoCode(int? promoCodeId)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            order.PromoCodeId = promoCodeId;

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }

        // Add/Remove product to cart.
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            string userId = User.GetUserId();
            await _productsService.AddToCartAsync(productId, userId, quantity);
            order.ProductsInBag = await _productsService.GetProductsInBagAsync(userId);

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }

        // Delete product from cart.
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            string userId = User.GetUserId();
            await _productsService.DeleteProductFromCartAsync(id, userId);
            order.ProductsInBag = await _productsService.GetProductsInBagAsync(userId);

            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));

            return View(nameof(Index), order);
        }

        // Save order to database and return unique order number.
        // Add new address delivery to database if not existing.
        // Remove products from user's bag.
        // Set the applied date to promo code if is applied.
        // Set new default address delivery to user.
        // Return unique order number to user.
        // Display the order summary page with all the necessary information for the order
        [HttpPost]
        public async Task<IActionResult> CheckoutSummary(string noteForDelivery)
        {
            OrderDTO order = JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));

            order.NoteForDelivery = noteForDelivery;

            string userId = User.GetUserId();
            string orderNumber = await _checkoutService.CheckoutSaveAsync(order, userId);

            OrderSummaryDTO orderSummary = await _checkoutService.OrderSummaryAsync(orderNumber);

            return View(orderSummary);
        }
    }
}
