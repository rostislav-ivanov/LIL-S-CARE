using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<CheckoutController> _localizer;

        public CheckoutController(
            ILogger<CheckoutController> logger,
            ICheckoutService checkoutService,
            IProductsService productsService,
            IAccountService accountService,
            IGuestService guestService,
            IEmailSender emailSender,
            IStringLocalizer<CheckoutController> localizer)
        {
            _logger = logger;
            _checkoutService = checkoutService;
            _productsService = productsService;
            _accountService = accountService;
            _guestService = guestService;
            _emailSender = emailSender;
            _localizer = localizer;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = User.GetUserId();

            OrderDTO order = await _checkoutService.GetOrderAsync(userId);
            if (userId != null)
            {
                order.ProductsInBag = await _productsService.GetProductsInBagAsync(userId);
            }
            else
            {
                order.ProductsInBag = await _guestService.GetProductsInBagAsync();
            }

            order = await _checkoutService.CalculateCheckout(order);

            SetSession(order);

            return View(order);
        }


        [AllowAnonymous]
        public async Task<IActionResult> SelectDeliveryMethod(int deliveryMethodId)
        {
            OrderDTO order = GetSession();

            order.Address = new AddressOrderDTO();
            order.DeliveryMethodId = deliveryMethodId;
            order.IsSelectedAddress = false;

            if (deliveryMethodId == 1)
            {
                order.Address.ShippingProviders = await _accountService.GetShippingProvidersAsync();
                order.Address.IsShippingToOffice = true;
            }

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Select the shipping provider for office delivery
        // Get the cities for the selected shipping provider.
        [AllowAnonymous]
        public async Task<IActionResult> SelectShippingProvider(int shippingProviderId)
        {
            OrderDTO order = GetSession();

            order.Address.ShippingProviderId = shippingProviderId;
            order.Address.ShippingProviderCities = await _accountService.GetShippingProviderCitiesAsync(shippingProviderId);
            order.Address.ShippingProviderCity = string.Empty;
            order.Address.ShippingOfficeId = null;

            SetSession(order);

            return View(nameof(Index), order);
        }


        // Select the city for office delivery
        // Get the shipping offices for the selected city.
        [AllowAnonymous]
        public async Task<IActionResult> SelectShippingCity(string city)
        {
            OrderDTO order = GetSession();

            order.Address.ShippingProviderCity = city;
            order.Address.ShippingOffices = await _accountService.GetShippingOfficesAsync(order.Address.ShippingProviderId, city);
            order.Address.ShippingOfficeId = null;

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Select the shipping office for office delivery
        [AllowAnonymous]
        public IActionResult SelectShippingOffice(int officeId)
        {
            OrderDTO order = GetSession();

            order.Address.ShippingOfficeId = officeId;
            order.Address.ShippingOffice = order.Address.ShippingOffices.FirstOrDefault(x => x.Id == officeId);

            SetSession(order);

            return View(nameof(Index), order);
        }

        // Add address of type delivery to office
        [AllowAnonymous]
        public async Task<IActionResult> AddOfficeDelivery(AddressOrderDTO addressDTO)
        {
            OrderDTO order = GetSession();

            if (addressDTO is null)
            {
                return BadRequest();
            }

            order!.Address!.FirstName = addressDTO.FirstName;
            order.Address.LastName = addressDTO.LastName;
            order.Address.PhoneNumber = addressDTO.PhoneNumber;

            ModelState.Remove("Country");
            ModelState.Remove("PostCode");
            ModelState.Remove("Town");
            ModelState.Remove("Address");


            if (ModelState.IsValid && order.Address.ShippingOffice != null)
            {
                order.IsSelectedAddress = true;
                order = await _checkoutService.CalculateCheckout(order);
            }

            SetSession(order);

            return View(nameof(Index), order);
        }


        // Add address of type delivery to address
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddAddressDelivery(AddressOrderDTO addressDTO)
        {
            OrderDTO order = GetSession();

            order.Address = addressDTO;

            if (addressDTO is null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                order.IsSelectedAddress = true;
                order = await _checkoutService.CalculateCheckout(order);
            }

            SetSession(order);

            return View(nameof(Index), order);
        }

        public async Task<IActionResult> EditDeliveryAddress()
        {
            OrderDTO order = GetSession();

            order.IsSelectedAddress = false;

            if (order.Address.IsShippingToOffice && order.Address.ShippingOffice != null)
            {
                order.Address.ShippingProviders = await _accountService.GetShippingProvidersAsync();
                order.Address.ShippingProviderId = order.Address.ShippingOffice.ShippingProviderId;
                order.Address.ShippingProviderCities = await _accountService.GetShippingProviderCitiesAsync(order.Address.ShippingProviderId);
                order.Address.ShippingProviderCity = order.Address.ShippingOffice.City;
                order.Address.ShippingOffices = await _accountService.GetShippingOfficesAsync(order.Address.ShippingProviderId, order.Address.ShippingProviderCity);
                order.Address.ShippingOfficeId = order.Address.ShippingOffice.Id;
            }

            SetSession(order);

            return View(nameof(Index), order);

        }


        // Select the payment method for the order.
        public async Task<IActionResult> DiscountWithPromoCode(int promoCodeId)
        {
            OrderDTO order = GetSession();

            order.PromoCodeId = promoCodeId;

            order = await _checkoutService.CalculateCheckout(order);

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

            order = await _checkoutService.CalculateCheckout(order);
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

            order = await _checkoutService.CalculateCheckout(order);
            SetSession(order);

            return View(nameof(Index), order);
        }

        // Save order to database and return unique order number.
        // Add new address delivery to database if not existing.
        // Remove products from user's bag.
        // Remove ordered quantity from products store
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
                string subject = $"{_localizer["Thank you for shopping with us"]} (#{orderNumber})";
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
                                    <tr>
                                      <td
                                        colspan=""3""
                                        style=""padding-top: 30px""
                                      ></td>
                                    </tr>
                                    <tr>
                                      <td valign=""top"">
                                        <table
                                          border=""0""
                                          cellpadding=""0""
                                          cellspacing=""0""
                                          width=""100%""
                                        >
                                          <tbody>
                                            <tr>
                                              <td style=""padding-right: 20px"">
                                                <table
                                                  border=""0""
                                                  cellpadding=""0""
                                                  cellspacing=""0""
                                                  width=""100%""
                                                >
                                                  <tbody>
                                                    <tr>
                                                      <td>
                                                        {product.Name}
                                                      </td>
                                                    </tr>
                                                    <tr>
                                                      <td>{_localizer["Price"]}: {product.Price} {_localizer["Currency"]}</td>
                                                    </tr>
                                                  </tbody>
                                                </table>
                                              </td>
                                            </tr>
                                          </tbody>
                                        </table>
                                      </td>
                                      <td
                                        valign=""top""
                                        width=""80""
                                      >
                                        {_localizer["Quantity"]}: {product.Quantity}
                                      </td>
                                      <td
                                        align=""right""
                                        width=""80""
                                        valign=""top""
                                      >
                                        {product.Quantity * product.Price} {_localizer["Currency"]}
                                      </td>
                                    </tr>
                    
");
            };

            string discount = orderSummary.Discount > 0 ? $@"
                                    <tr>
                                      <td
                                        colspan=""3""
                                        style=""padding-top: 30px""
                                      ></td>
                                    </tr>
                                    <tr>
                                      <td valign=""top"">
                                        <table
                                          border=""0""
                                          cellpadding=""0""
                                          cellspacing=""0""
                                          width=""100%""
                                        >
                                          <tbody>
                                            <tr>
                                              <td style=""padding-right: 20px"">
                                                <table
                                                  border=""0""
                                                  cellpadding=""0""
                                                  cellspacing=""0""
                                                  width=""100%""
                                                >
                                                  <tbody>
                                                    <tr>
                                                      <td>{_localizer["Discount"]}:</td>
                                                    </tr>
                                                  </tbody>
                                                </table>
                                              </td>
                                            </tr>
                                          </tbody>
                                        </table>
                                      </td>
                                      <td valign=""top"" width=""80""></td>
                                      <td align=""right"" width=""80"" valign=""top"">
                                        - {orderSummary.Discount} лв.
                                      </td>
                                    </tr>
                                " : string.Empty;

            string addressDelivery = string.Empty;
            if (orderSummary.IsShippingToOffice)
            {
                addressDelivery = $@"                                                                        
                                                                        <tr>
                                                                          <td style=""padding-bottom: 20px;"">
                                                                             {_localizer["Delivery to courier office"]}
                                                                          </td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.ShippingProviderName}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.ShippingOfficeCity}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.ShippingOfficeAddress}</td>
                                                                        </tr>
                                                                        <tr>    
                                                                          <td style=""padding-bottom: 20px;"">
                                                                            {_localizer["Recipient"]}
                                                                          </td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.FirstName} {orderSummary.LastName}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.PhoneNumber}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.Email}</td>
                                                                        </tr>";
            }
            else
            {
                addressDelivery = $@"                                                                        
                                                                        <tr>
                                                                          <td style=""padding-bottom: 20px;"">
                                                                            {_localizer["Delivery to customer address"]}
                                                                          </td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.FirstName} {orderSummary.LastName}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.Country}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.District}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.PostCode} {orderSummary.Town}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.Address}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.PhoneNumber}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{orderSummary.Email}</td>
                                                                        </tr>";
            }


            string message = $@"
<table
  bgcolor=""#ffffff""
  border=""0""
  cellpadding=""0""
  cellspacing=""0""
  width=""660""
  align=""center""
  style=""
    table-layout: fixed;
    border-top: 1px solid #6f6f6f;
    border-right: 1px solid #6f6f6f;
    border-bottom: 1px solid #6f6f6f;
    border-left: 1px solid #6f6f6f;
  ""
>
  <tbody>
    <tr>
      <td style=""padding-left: 50px; padding-right: 50px"">
        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
          <tbody>
            <tr>
              <td style=""padding-top: 50px; padding-bottom: 30px"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                  <tbody>
                    <tr>
                      <td>
                        <table
                          border=""0""
                          cellpadding=""0""
                          cellspacing=""0""
                          width=""100%""
                        >
                          <tbody>
                            <tr>
                              <td
                                style=""padding-bottom: 15px; text-align: center""
                              >
                                <img
                                  src=""https://ci3.googleusercontent.com/meips/ADKq_NbT0qnno1iUypLWulgVCrOQPje2wj6t6jAHOCbIKs7zx-dIC2ciD5WVp2OOIFRrxJdTHiuEKq4yg1bedmU8fER84OSNUIgGeo9DxcVvC8aOLa7UA-WvjHCSK8naMa4tQx8zLS09PvFJ3ZrmqoT2FilFkZAW6rfScx2XvSM_eQuw6x6L6xzEXyfS=s0-d-e1-ft#https://static.wixstatic.com/media/a6694c_4611c8a766664ff29bce6824767cb6c1~mv2.jpg/v1/fit/w_100,h_100,q_90/file.jpg""
                                />
                              </td>
                            </tr>
                            <tr>
                              <td
                                style=""
                                  padding-bottom: 56px;
                                  text-align: center;
                                  font-size: larger;
                                ""
                              >
                                Lil's Care handmade
                              </td>
                            </tr>

                            <tr>
                              <td style=""padding-bottom: 19px"">
                                {_localizer["Thank you for the order!"]}
                              </td>
                            </tr>

                            <tr>
                              <td style=""padding-bottom: 54px"">
                                {_localizer["We will be in touch to confirm availability and address."]}
                              </td>
                            </tr>

                            <tr>
                              <td>
                                <table
                                  border=""0""
                                  cellpadding=""0""
                                  cellspacing=""0""
                                  width=""100%""
                                  style=""color: #6f6f6f""
                                >
                                  <tbody>
                                    <tr>
                                      <td
                                        width=""50%""
                                        style=""padding-right: 25px""
                                        valign=""top""
                                      >
                                        {_localizer["order no"]} #{orderSummary.OrderNumber}
                                      </td>

                                      <td
                                        width=""50%""
                                        style=""padding-left: 25px""
                                        valign=""top""
                                      >
                                        {_localizer["Created on"]} {orderSummary.OrderDate.ToString("dd/MM/yyyy")}
                                      </td>
                                    </tr>
                                    <tr>
                                      <td
                                        colspan=""2""
                                        style=""
                                          padding-top: 25px;
                                          border-bottom: 1px solid #dadada;
                                        ""
                                      ></td>
                                    </tr>
                                    <tr>
                                      <td
                                        colspan=""2""
                                        style=""padding-bottom: 25px""
                                      ></td>
                                    </tr>

                                    <tr>
                                      <td valign=""top"">
                                        <table
                                          border=""0""
                                          cellpadding=""0""
                                          cellspacing=""0""
                                          width=""100%""
                                        >
                                          <tbody>
                                            <tr>
                                              <td>
                                                <table
                                                  border=""0""
                                                  cellpadding=""0""
                                                  cellspacing=""0""
                                                  width=""100%""
                                                >
                                                  <tbody>
                                                    <tr>
                                                      <td
                                                        style=""
                                                          padding-bottom: 20px;
                                                        ""
                                                      >
                                                        {_localizer["Delivery Information"]}
                                                      </td>
                                                    </tr>
                                                    {addressDelivery}
                                                  </tbody>
                                                </table>
                                              </td>
                                            </tr>
                                          </tbody>
                                        </table>
                                      </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                      </td>
                    </tr>
                  </tbody>
                </table>

                <span></span>
              </td>
            </tr>
            <tr>
              <td
                style=""
                  border-top: 1px solid #6f6f6f;
                  border-bottom: 1px solid #6f6f6f;
                  padding-top: 30px;
                  padding-bottom: 30px;
                ""
              >
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                  <tbody>
                    <tr>
                      <td>
                        <table
                          border=""0""
                          cellpadding=""0""
                          cellspacing=""0""
                          width=""100%""
                        >
                          <tbody>
                            <tr>
                              <td>{_localizer["Order Summary"]}</td>
                            </tr>
                            <tr>
                              <td style=""padding-bottom: 30px"">
                                <table
                                  border=""0""
                                  cellpadding=""0""
                                  cellspacing=""0""
                                  width=""100%""
                                >
                                  <tbody>
                                    {sb.ToString()}
                                    {discount}
                                    <tr>
                                      <td
                                        colspan=""3""
                                        style=""padding-bottom: 30px""
                                      ></td>
                                    </tr>

                                    <tr>
                                      <td
                                        colspan=""3""
                                        style=""border-bottom: 1px solid #dadada""
                                      ></td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>

                            <tr>
                              <td
                                align=""right""
                                style=""padding-top: 10px; color: #343434""
                              >
                                <table
                                  border=""0""
                                  cellpadding=""0""
                                  cellspacing=""0""
                                >
                                  <tbody>
                                    <tr>
                                      <td style=""padding-right: 25px"">
                                        {_localizer["Subtotal"]}:
                                      </td>
                                      <td
                                        align=""right""
                                        style=""padding-left: 30px""
                                      >
                                        {orderSummary.SubTotal} {_localizer["Currency"]}
                                      </td>
                                    </tr>
                                    <tr>
                                      <td
                                        style=""
                                          padding-right: 25px;
                                          padding-top: 10px;
                                          padding-bottom: 10px;
                                        ""
                                      >
                                        {_localizer["Shipping"]}:
                                      </td>
                                      <td
                                        align=""right""
                                        style=""
                                          padding-left: 30px;
                                          padding-top: 10px;
                                          padding-bottom: 10px;
                                        ""
                                      >
                                        {orderSummary.ShippingPrice} {_localizer["Currency"]}
                                      </td>
                                    </tr>
                                    <tr>
                                      <td
                                        colspan=""2""
                                        style=""
                                          padding: 0;
                                          border-bottom: 1px solid #dadada;
                                        ""
                                      ></td>
                                    </tr>
                                    <tr>
                                      <td
                                        style=""
                                          padding-right: 25px;
                                          padding-top: 10px;
                                          padding-bottom: 0;
                                        ""
                                      >
                                        {_localizer["Total"]}:
                                      </td>
                                      <td
                                        align=""right""
                                        style=""
                                          padding-left: 30px;
                                          padding-top: 10px;
                                          padding-bottom: 0;
                                        ""
                                      >
                                        {orderSummary.Total} {_localizer["Currency"]}
                                      </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </td>
            </tr>
            <tr>
              <td style=""padding-top: 30px; padding-bottom: 60px"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                  <tbody>
                    <tr>
                      <td>
                        <table
                          border=""0""
                          cellpadding=""0""
                          cellspacing=""0""
                          width=""100%""
                        >
                          <tbody>
                            <tr>
                              <td style=""padding-bottom: 30px"">
                                <table
                                  border=""0""
                                  cellpadding=""0""
                                  cellspacing=""0""
                                  width=""100%""
                                >
                                  <tbody>
                                    <tr>
                                      <td style=""padding-bottom: 20px"">
                                        {_localizer["Need help? Question?"]}
                                      </td>
                                    </tr>

                                    <tr>
                                      <td>
                                        {_localizer["Send us an email"]}:
                                        <a
                                          href=""mailto:lils.care.handmade@gmail.com""
                                          target=""_blank""
                                          >lils.care.handmade@gmail.com</a
                                        >
                                      </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>

                            <tr>
                              <td>
                                <table
                                  border=""0""
                                  cellpadding=""0""
                                  cellspacing=""0""
                                  width=""100%""
                                >
                                  <tbody>
                                    <tr>
                                      <td style=""padding-bottom: 20px"">
                                        {_localizer["This email was sent by"]} Lil's Care
                                        handmade
                                      </td>
                                    </tr>
                                    <tr>
                                      <td>
                                        <a
                                          href=""https://www.lilscare.com/""
                                          target=""_blank""
                                          >https://www.lilscare.com/</a
                                        >
                                      </td>
                                    </tr>
                                  </tbody>
                                </table>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </td>
            </tr>
          </tbody>
        </table>
      </td>
    </tr>
  </tbody>
</table>
";

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
