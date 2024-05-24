using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.AdminOrderDetails;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LilsCareApp.Areas.Admin.Controllers
{
    public class OrderDetailsController : AdminController
    {
        private readonly IAdminOrderService _adminOrderService;
        private readonly IAdminOrderDetailsService _adminOrderDetailsService;
        private readonly ICheckoutService _checkoutService;
        private readonly IEmailSender _emailSender;


        public OrderDetailsController(
            IAdminOrderService adminOrderService,
            IAdminOrderDetailsService adminOrderDetailsService,
            ICheckoutService checkoutService,
            IEmailSender emailSender)
        {
            _adminOrderService = adminOrderService;
            _adminOrderDetailsService = adminOrderDetailsService;
            _checkoutService = checkoutService;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            AdminOrderDetailsDTO order = await _adminOrderDetailsService.GetOrderDetailsAsync(id);
            order.StatusesOrder = await _adminOrderService.GetStatusesOrderAsync();
            order.Products = await _adminOrderDetailsService.GetProductsNameAsync();
            order.DeliveryMethods = await _checkoutService.GetDeliveryMethodsAsync();
            order.PaymentMethods = await _checkoutService.GetPaymentMethodsAsync();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrackingCode(int id, string trackingNumber)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.AddTrackingCodeAsync(id, trackingNumber);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> ChangeStatus(int id, int statusId)
        {
            if (id == 0 || statusId == 0)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.ChangeStatusAsync(id, statusId);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> ChangeDeliveryMethod(int id, int deliveryMethodId)
        {
            if (id == 0 || deliveryMethodId == 0)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.ChangeDeliveryMethodAsync(id, deliveryMethodId);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> ChangePayment(int id, bool? isPaid)
        {
            if (id == 0 || isPaid == null)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.ChangePaymentAsync(id, isPaid);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> AddProductToOrder(int id, int productId)
        {
            if (id == 0 || productId == 0)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.AddProductToOrderAsync(id, productId);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> RemoveProductFromOrder(int id, int productId)
        {
            if (id == 0 || productId == 0)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.RemoveProductFromOrderAsync(id, productId);

            return RedirectToAction(nameof(Index), new { id });
        }

        public async Task<IActionResult> AddQuantityToProduct(int id, int productId, int quantity)
        {
            if (id == 0 || productId == 0 || quantity == 0)
            {
                return BadRequest();
            }

            await _adminOrderDetailsService.AddQuantityToProductAsync(id, productId, quantity);

            return RedirectToAction(nameof(Index), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> EditDiscount(int id, decimal discount)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), new { id });
            }

            await _adminOrderDetailsService.EditDiscountAsync(id, discount);

            return RedirectToAction(nameof(Index), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> AddOfficeDeliveryAsync(AdminOrderDetailsDTO model)
        {
            ModelState.Remove("Country");
            ModelState.Remove("PostCode");
            ModelState.Remove("Town");
            ModelState.Remove("Address");

            if (model is null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _adminOrderDetailsService.AddOfficeDeliveryAsync(model);
            }

            return RedirectToAction(nameof(Index), new { model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> AddHomeDeliveryAsync(AdminOrderDetailsDTO model)
        {
            ModelState.Remove("ShippingProviderName");
            ModelState.Remove("OfficeCity");
            ModelState.Remove("OfficeAddress");

            if (model is null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _adminOrderDetailsService.AddHomeDeliveryAsync(model);
            }

            return RedirectToAction(nameof(Index), new { model.Id });
        }

        public async Task<IActionResult> SendConfirmationEmail(int id)
        {
            var order = await _adminOrderDetailsService.GetOrderDetailsAsync(id);
            if (order == null)
            {
                return BadRequest();
            }

            var userEmail = order.Email ?? order.AppUserName;

            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest();
            }

            string message = CreateConfirmationEmailMessage(order);

            string subject = $"Благодарим ви, че пазарувате при нас (#{order.OrderNumber})";
            await _emailSender.SendEmailAsync(userEmail, subject, message);

            return RedirectToAction(nameof(Index), new { id });
        }

        private string CreateConfirmationEmailMessage(AdminOrderDetailsDTO order)
        {

            StringBuilder sb = new();
            foreach (var product in order.ProductsOrders)
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
                                                      <td>Цена: {product.Price} {order.Currency}</td>
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
                                        Количество: {product.Quantity}
                                      </td>
                                      <td
                                        align=""right""
                                        width=""80""
                                        valign=""top""
                                      >
                                        {product.Quantity * product.Price} {order.Currency}
                                      </td>
                                    </tr>
                    
");
            };

            string discount = order.Discount > 0 ? $@"
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
                                                      <td>Отстъпка:</td>
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
                                        - {order.Discount} {order.Currency}
                                      </td>
                                    </tr>
                                " : string.Empty;

            string addressDelivery = string.Empty;
            if (order.DeliveryMethodId == 1)
            {
                addressDelivery = $@"                                                                        
                                                                        <tr>
                                                                          <td style=""padding-bottom: 20px;"">
                                                                             Доставка до офис на куриер
                                                                          </td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.ShippingProviderName}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.OfficeCity}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.OfficeAddress}</td>
                                                                        </tr>
                                                                        <tr>    
                                                                          <td style=""padding-bottom: 20px;"">
                                                                            Получател
                                                                          </td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.FirstName} {order.LastName}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.PhoneNumber}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.Email}</td>
                                                                        </tr>";
            }
            else
            {
                addressDelivery = $@"                                                                        
                                                                        <tr>
                                                                          <td style=""padding-bottom: 20px;"">
                                                                            Доставка до адрес на клиент
                                                                          </td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.FirstName} {order.LastName}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.Country}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.District}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.PostCode} {order.Town}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.Address}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.PhoneNumber}</td>
                                                                        </tr>
                                                                        <tr>
                                                                          <td>{order.Email}</td>
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
                                Благодарим за поръчката!
                              </td>
                            </tr>

                            <tr>
                              <td style=""padding-bottom: 54px"">
                                Може да проследите вашата поръчка на следния номер: {order.TrackingNumber}
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
                                        № на поръчка #{order.OrderNumber}
                                      </td>

                                      <td
                                        width=""50%""
                                        style=""padding-left: 25px""
                                        valign=""top""
                                      >
                                        Направена на {order.CreatedOn.ToString("dd/MM/yyyy")}
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
                                      <td
                                        width=""50%""
                                        style=""padding-right: 25px""
                                        valign=""top""
                                      >
                                        tracking number:
                                      </td>

                                      <td
                                        width=""50%""
                                        style=""padding-left: 25px""
                                        valign=""top""
                                      >
                                        {order.TrackingNumber}
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
                                                        Информация за доставка
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
                              <td>Резюме на поръчката</td>
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
                                        Междинна сума:
                                      </td>
                                      <td
                                        align=""right""
                                        style=""padding-left: 30px""
                                      >
                                        {order.SubTotal} {order.Currency}
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
                                        Доставка:
                                      </td>
                                      <td
                                        align=""right""
                                        style=""
                                          padding-left: 30px;
                                          padding-top: 10px;
                                          padding-bottom: 10px;
                                        ""
                                      >
                                        {order.ShippingPrice} {order.Currency}
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
                                        Общо:
                                      </td>
                                      <td
                                        align=""right""
                                        style=""
                                          padding-left: 30px;
                                          padding-top: 10px;
                                          padding-bottom: 0;
                                        ""
                                      >
                                        {order.Total} {order.Currency}
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
                                        Нужда от помощ? Въпрос?
                                      </td>
                                    </tr>

                                    <tr>
                                      <td>
                                        Изпратете ни имейл:
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
                                        Този имейл беше изпратен от Lil's Care
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
    }
}
