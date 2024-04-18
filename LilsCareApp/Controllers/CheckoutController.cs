using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace LilsCareApp.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ICheckoutService _checkoutService;
        private readonly IProductsService _productsService;
        private readonly IAccountService _accountService;
        private readonly IGuestService _guestService;
        private readonly IEmailSender _emailSender;

        public CheckoutController(
            ILogger<CheckoutController> logger,
            ICheckoutService checkoutService,
            IProductsService productsService,
            IAccountService accountService,
            IGuestService guestService,
            IEmailSender emailSender)
        {
            _logger = logger;
            _checkoutService = checkoutService;
            _productsService = productsService;
            _accountService = accountService;
            _guestService = guestService;
            _emailSender = emailSender;
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
            if (User.GetUserEmail() != null)
            {
                string message = CreateOrderSummaryEmailMessage(orderSummary);
                string subject = $"Вашата поръчка (#{orderNumber}) е приета";
                await _emailSender.SendEmailAsync(User.GetUserEmail(), subject, message);
            }

            return View(orderSummary);
        }

        private string CreateOrderSummaryEmailMessage(OrderSummaryDTO orderSummary)
        {
            StringBuilder sb = new();
            foreach (var product in orderSummary.Products)
            {
                sb.Append($@"
                    <div class=""row mb-5"">
                        <div class=""col-5"">
                            <div class=""product-img"">
                                    <img src=""{product.ImagePath}""
                                         class=""img-fluid w-100""
                                         alt="""" />
                            </div>
                        </div>
                        <div class=""col-7"">
                            <div>
                                <p>{product.Name}</p>
                                <p>Цена: {product.Price} лв.</p>

                            </div>
                            <div class=""d-flex justify-content-between align-items-center mt-3"">
                                <div class=""d-flex justify-content-start align-items-center my-2"">
                                    <span class=""mx-2"">Количество: {product.Quantity}</span>
                                </div>
                                <p class=""mb-0"">
                                    <span><strong>{product.Quantity * product.Price} лв.</strong></span>
                                </p>
                            </div>
                        </div>
                    </div>");
            };


            string message = $@"<div class=""container p-3"">
            <div class=""row g-5 p-3"">
                <hr />
                <h5 class=""text-center"">Вие направихте поръчка #<strong>{orderSummary.OrderNumber}</strong> от {orderSummary.OrderDate.ToString("dd/MM/yyyy")}</h5>
                <!-- Client's data and Delivery address Start -->
                <div class=""col-lg-6"">
                    <hr />
                        <h5 class=""py-3 m-0"">Доставка до офис на куриер</h5>
                        <div class=""row"" style=""opacity: 0.9"">
                            <p>{orderSummary.ShippingProviderName}</p>
                            <p>{orderSummary.ShippingOfficeCity}</p>
                            <p>{orderSummary.ShippingOfficeAddress}</p>
                            <p>{orderSummary.FirstName} {orderSummary.LastName}</p>
                            <p>{orderSummary.PhoneNumber}</p>
                            <textarea rows=""4"" placeholder=""{orderSummary.NoteForDelivery}"" disabled></textarea>
                        </div>
                    <hr />
                    <!-- Payment Start -->
                    <h5>Метод на плащане</h5>
                    <p style=""opacity: 0.9"">{orderSummary.PaymentMethod}</p>
                    <!-- Payment Start -->
                    <hr />
                </div>
                <!-- Client's data and Delivery address End -->

                <!-- Order Summary Start -->
                <div class=""col-lg-6"">
                    <div class=""container mt-4 px-4 pb-2 rounded""
                         style=""background-color: rgb(var(--app-bg-secondary))"">
                            <h5 class=""py-4 m-0"">Резюме на поръчката {orderSummary.Products.Sum(p => p.Quantity)}</h5>

                        <hr class=""mt-0"" />
                        <!-- Product Start -->
                        {sb.ToString()}
                        <!-- Product End -->
                        <!-- Promo Code Start -->
                        <div style=""display: block"">
                            <div class=""d-flex justify-content-between"">
                                <span>Промо код:</span>
                                <span>
                                    <strong> - {orderSummary.Discount} лв.</strong>
                                </span>
                            </div>
                        </div>
                        <!-- Promo Code Start -->
                        <hr />
                        <!-- Subtotal Start -->
                        <div class=""d-flex justify-content-between mb-3"">
                            <span>Междинна сума</span>
                            <span class=""mb-0"">
                                <strong>{orderSummary.SubTotal} лв.</strong>
                            </span>
                        </div>
                        <!-- Subtotal End -->
                        <!-- Delivery Start -->
                        <div class=""d-flex justify-content-between mb-3"">
                            <span>Доставка</span>
                            <span class=""mb-0"">
                                    <strong>{orderSummary.ShippingPrice} лв.</strong>
                            </span>
                        </div>
                        <!-- Delivery End -->
                        <hr />
                        <!-- Total Price Start -->
                        <div class=""d-flex justify-content-between my-3 fs-4"">
                            <span>Общо :</span>
                            <span>{orderSummary.Total} лв.</span>
                        </div>
                        <!-- Total Price End -->
                    </div>
                </div>
                <!-- Order Summary End -->
            </div>
        </div>";

            return message;
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
