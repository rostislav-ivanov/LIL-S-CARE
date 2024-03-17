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
            checkout.DeliveryTypes = new List<DeliveryTypeDTO>()
                {
                    new DeliveryTypeDTO()
                    {
                        Id = 1,
                        Name = "до адрес",
                        IsDeliveryToAddress = true
                    },
                    new DeliveryTypeDTO()
                    {
                        Id = 2,
                        Name = "до офис Еконт",
                        IsDeliveryToAddress = false
                    },
                    new DeliveryTypeDTO()
                    {
                        Id = 3,
                        Name = "до офис Спиди",
                        IsDeliveryToAddress = false
                    }
            };


            checkout.ProductsInBag = await _service.GetProductsInBagAsync(userId);

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));
            return View(checkout);
        }

        [AllowAnonymous]
        public IActionResult SelectDeliveryType(int deliveryTypeId)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.DeliveryType = checkout.DeliveryTypes.FirstOrDefault(dt => dt.Id == deliveryTypeId);
            if (!checkout.DeliveryType.IsDeliveryToAddress)
            {
                checkout.OfficeDelivery = new OfficeDeliveryDTO()
                {
                    Office = new OfficeDTO()
                    {
                        City = null,
                        Address = null
                    },
                    Offices = new List<OfficeDTO>()
                    {
                        new OfficeDTO()
                        {
                            Id = 1,
                            City = "град1",
                            Address = "адрес1",
                            Price = 6.20m
                        },
                        new OfficeDTO()
                        {
                            Id = 2,
                            City = "град1",
                            Address = "адрес2",
                            Price = 7.20m
                        },
                        new OfficeDTO()
                        {
                            Id = 3,
                            City = "град1",
                            Address = "адрес3",
                            Price = 8.20m
                        },
                        new OfficeDTO()
                        {
                            Id = 4,
                            City = "град2",
                            Address = "адрес1",
                            Price = 7.20m
                        },
                        new OfficeDTO()
                        {
                            Id = 5,
                            City = "град2",
                            Address = "адрес2",
                            Price = 10.20m
                        },
                    }
                };
            }
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult EditDeliveryType()
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.DeliveryType = null;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DeliveryToAddress(AddressDeliveryDTO addressDelivery)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery = addressDelivery;
            if (ModelState.IsValid)
            {
                checkout.AddressDelivery.IsValid = true;
            }

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult EditDeliveryToAddress()
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.AddressDelivery.IsValid = false;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult SelectOfficeCity(string city)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.OfficeDelivery.Office.City = city;
            checkout.OfficeDelivery.Office.Address = null;
            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }

        [AllowAnonymous]
        public IActionResult SelectOfficeDelivery(int officeId)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.OfficeDelivery.Office = checkout.OfficeDelivery.Offices.FirstOrDefault(o => o.Id == officeId);

            HttpContext.Session.SetString("Checkout", JsonConvert.SerializeObject(checkout));

            return View(nameof(Index), checkout);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DeliveryToOffice(OfficeDeliveryDTO officeDelivery)
        {
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
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
            CheckoutDTO checkout = JsonConvert.DeserializeObject<CheckoutDTO>(HttpContext.Session.GetString("Checkout"));
            checkout.OfficeDelivery.IsValid = false;
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

    }
}
