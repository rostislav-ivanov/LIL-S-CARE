using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Services;
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
        private readonly IAccountService _accountService;
        private readonly IGuestService _guestService;

        public CheckoutController(
            ILogger<CheckoutController> logger,
            ICheckoutService checkoutService,
            IProductsService productsService,
            IAccountService accountService,
            IGuestService guestService)
        {
            _logger = logger;
            _checkoutService = checkoutService;
            _productsService = productsService;
            _accountService = accountService;
            _guestService = guestService;
        }

        // GET: CheckoutController
        // Display the order summary page with all the necessary information for the order
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string userId = User.GetUserId();

            OrderDTO order = new OrderDTO();
            order.PaymentMethods = await _checkoutService.GetPaymentMethodsAsync();
            if (userId != null)
            {
                order.ProductsInBag = await _productsService.GetProductsInBagAsync(userId);
                order.PromoCodes = await _checkoutService.GetPromoCodesAsync(userId);

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
            }
            else
            {
                order.ProductsInBag = await _guestService.GetProductsInBagAsync();
            }


            SetSession(order);

            return View(order);
        }



        // Select the delivery type of address (office or address).
        // If the delivery type is office, get the shipping provider.
        [AllowAnonymous]
        public async Task<IActionResult> SelectDeliveryType(bool isShippingToOffice)
        {
            OrderDTO order = GetSession();

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

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Select the shipping provider for office delivery
        // Get the cities for the selected shipping provider.
        [AllowAnonymous]
        public async Task<IActionResult> SelectShippingProvider(int shippingProviderId)
        {
            OrderDTO order = GetSession();

            order.Office.ShippingProviderId = shippingProviderId;
            order.Office.ShippingProviderCities = await _accountService.GetShippingProviderCitiesAsync(shippingProviderId);
            order.Office.CityName = null;
            order.Office.ShippingOfficeId = null;

            SetSession(order);

            return View(nameof(Index), order);
        }


        // Select the city for office delivery
        // Get the shipping offices for the selected city.
        [AllowAnonymous]
        public async Task<IActionResult> SelectShippingCity(string city)
        {
            OrderDTO order = GetSession();

            order.Office.CityName = city;
            order.Office.ShippingOffices = await _accountService.GetShippingOfficesAsync(order.Office.ShippingProviderId, city);
            order.Office.ShippingOfficeId = null;

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Select the shipping office for office delivery
        [AllowAnonymous]
        public IActionResult SelectShippingOffice(int officeId)
        {
            OrderDTO order = GetSession();

            order.Office.ShippingOfficeId = officeId;

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Add or Edit address of type delivery to office
        [AllowAnonymous]
        public async Task<IActionResult> AddOfficeDelivery(OfficeDTO officeDTO)
        {
            OrderDTO order = GetSession();

            order!.Office!.FirstName = officeDTO.FirstName;
            order.Office.LastName = officeDTO.LastName;
            order.Office.PhoneNumber = officeDTO.PhoneNumber;

            if (ModelState.IsValid && order.Office.IsSelectedOffice())
            {
                order.IsValidOrder = true;
            }

            SetSession(order);

            return View(nameof(Index), order);
        }


        // Add or Edit address of type delivery to address
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddAddressDelivery(AddressDTO addressDTO)
        {
            OrderDTO order = GetSession();

            order.Address = addressDTO;

            if (addressDTO is null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                order.IsValidOrder = true;
            }

            SetSession(order);

            return View(nameof(Index), order);
        }


        // Select the payment method for the order.
        public async Task<IActionResult> DiscountWithPromoCode(int? promoCodeId)
        {
            OrderDTO order = GetSession();

            order.PromoCodeId = promoCodeId;

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Add/Remove product to cart.
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            OrderDTO order = GetSession();

            if (User.GetUserId() != null)
            {
                await _productsService.AddToCartAsync(productId, User.GetUserId(), quantity);
                order.ProductsInBag = await _productsService.GetProductsInBagAsync(User.GetUserId());
            }
            else
            {
                _guestService.AddToCart(productId, quantity);
                order.ProductsInBag = await _guestService.GetProductsInBagAsync();
            }

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Delete product from cart.
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            OrderDTO order = GetSession();

            if (User.GetUserId() != null)
            {
                await _productsService.DeleteProductFromCartAsync(id, User.GetUserId());
                order.ProductsInBag = await _productsService.GetProductsInBagAsync(User.GetUserId());
            }
            else
            {
                _guestService.DeleteProductFromCart(id);
                order.ProductsInBag = await _guestService.GetProductsInBagAsync();
            }

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Save order to database and return unique order number.
        // Add new address delivery to database if not existing.
        // Remove products from user's bag.
        //remove ordered quantity from products store
        // Set the applied date to promo code if is applied.
        // Set new default address delivery to user.
        // Return unique order number to user.
        // Display the order summary page with all the necessary information for the order
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CheckoutSummary(string noteForDelivery)
        {
            OrderDTO order = GetSession();

            order.NoteForDelivery = noteForDelivery;

            string orderNumber = string.Empty;
            if (User.GetUserId() != null)
            {
                orderNumber = await _checkoutService.CheckoutSaveAsync(order, User.GetUserId());
            }
            else
            {
                orderNumber = await _guestService.CheckoutSaveAsync(order);
            }

            OrderSummaryDTO orderSummary = await _checkoutService.OrderSummaryAsync(orderNumber);

            return View(orderSummary);
        }


        private OrderDTO? GetSession()
        {
            return JsonConvert.DeserializeObject<OrderDTO>(HttpContext.Session.GetString("Order"));
        }

        private void SetSession(OrderDTO? order)
        {
            HttpContext.Session.SetString("Order", JsonConvert.SerializeObject(order));
        }
    }
}
