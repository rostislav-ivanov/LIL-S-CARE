//using LilsCareApp.Core.Models.Account;
//using LilsCareApp.Core.Models.Checkout;
//using LilsCareApp.Core.Services;
//using LilsCareApp.Infrastructure.Data.Models;

//namespace LilsCareApp.Tests.UnitTest
//{
//    public class CheckoutServiceTests : UnitTestsBase
//    {
//        private string userId;
//        private CheckoutService _checkoutService;
//        private ProductsService _productsService;

//        [OneTimeSetUp]
//        public void SetUp()
//        {
//            _checkoutService = new CheckoutService(_mockDbContext);
//            _productsService = new ProductsService(_mockDbContext);
//            userId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef";
//        }

//        [Test]
//        public async Task GetDefaultAddressIdAsync_WhenCalled_ReturnDefaultAddressId()
//        {
//            // Act
//            var result = await _checkoutService.GetDefaultAddressIdAsync(userId);

//            // Assert
//            Assert.AreEqual(1, result);
//        }

//        [Test]
//        public async Task GetPaymentMethodsAsync_WhenCalled_ReturnPaymentMethods()
//        {
//            // Arrange
//            IEnumerable<PaymentMethod> expected =
//            [
//                new () { Id = 1, Type = "Наложен платеж" },
//                new () { Id = 2, Type = "С карта" },
//                new () { Id = 3, Type = "Банков превод" }
//            ];
//            // Act
//            var actual = await _checkoutService.GetPaymentMethodsAsync();

//            // Assert
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(expected.Count(), actual.Count());
//            for (int i = 0; i < expected.Count(); i++)
//            {
//                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
//                Assert.AreEqual(expected.ElementAt(i).Type, actual.ElementAt(i).Type);
//            }
//        }

//        [Test]
//        public async Task GetPromoCodesAsync_WhenCalled_ReturnPromoCodes()
//        {
//            // Arrange
//            IEnumerable<PromoCodeDTO> expected =
//            [
//            new ()
//            {
//                Id = 1,
//                Code = "-10 % за регистрация",
//                Discount = 0.1m,
//                ExpirationDate = DateTime.UtcNow.AddMonths(12),
//            },
//            new ()
//            {
//                Id = 2,
//                Code = "-20 % отстъпка",
//                Discount = 0.2m,
//                ExpirationDate = DateTime.UtcNow.AddMonths(12),
//            },
//            ];
//            // Act
//            var actual = await _checkoutService.GetPromoCodesAsync(userId);

//            // Assert
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(expected.Count(), actual.Count());
//            for (int i = 0; i < expected.Count(); i++)
//            {
//                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
//                Assert.AreEqual(expected.ElementAt(i).Code, actual.ElementAt(i).Code);
//                Assert.AreEqual(expected.ElementAt(i).Discount, actual.ElementAt(i).Discount);
//            }
//        }

//        //[Test]
//        //public async Task CheckoutSaveAsync_WhenCalled_ReturnUniqueOrderNumber()
//        //{
//        //    // Arrange
//        //    OrderDTO order = new()
//        //    {
//        //        ProductsInBag =
//        //        [
//        //            new ()
//        //            {
//        //                Id = 1,
//        //                Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
//        //                Price = 5.50m,
//        //                Optional = "Тегло:  25 г.",
//        //                Quantity = 3,
//        //                ImageUrl = "/files/products/product-01-image-01.webp"
//        //            },
//        //            new ()
//        //            {
//        //                Id = 2,
//        //                Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
//        //                Price = 4.00m,
//        //                Optional = "Тегло:  5 г.",
//        //                Quantity = 4,
//        //                ImageUrl = "/files/products/product-02-image-01.webp"
//        //            }
//        //        ],
//        //        PaymentMethodId = 1,
//        //        PromoCodeId = 1,
//        //        PromoCodes =
//        //        [
//        //            new ()
//        //            {
//        //                Id = 1,
//        //                Code = "-10 % за регистрация",
//        //                Discount = 0.1m,
//        //                ExpirationDate = DateTime.UtcNow.AddMonths(12),
//        //            },
//        //            new ()
//        //            {
//        //                Id = 2,
//        //                Code = "-20 % отстъпка",
//        //                Discount = 0.2m,
//        //                ExpirationDate = DateTime.UtcNow.AddMonths(12),
//        //            },
//        //        ],
//        //        NoteForDelivery = "Some note",
//        //        IsValidOrder = true,
//        //        Address = new AddressDTO
//        //        {
//        //            Id = 1,
//        //            FirstName = "Ivan",
//        //            LastName = "Ivanov",
//        //            PhoneNumber = "0888888888",
//        //            PostCode = "1000",
//        //            Address = "bul. Vitosha",
//        //            Town = "Sofia",
//        //            District = "Sofia",
//        //            Country = "Bulgaria",
//        //        }
//        //    };

//        //    Order expected = new()
//        //    {
//        //        StatusOrderId = 1,
//        //        PaymentMethodId = 1,
//        //        NoteForDelivery = "Some note",
//        //        ProductsOrders =
//        //        [
//        //            new ()
//        //            {
//        //                ProductId = 1,
//        //                Price = 5.50m,
//        //                Quantity = 3,
//        //                ImagePath = "/files/products/product-01-image-01.webp"
//        //            },
//        //            new ()
//        //            {
//        //                ProductId = 2,
//        //                Price = 4.00m,
//        //                Quantity = 4,
//        //                ImagePath = "/files/products/product-02-image-01.webp"
//        //            }
//        //        ],
//        //        PromoCodeId = 1,
//        //        SubTotal = 29.25m,
//        //        Discount = 3.25m,
//        //        ShippingPrice = 8m,
//        //        Total = 37.25m,
//        //        AddressDelivery = new AddressDelivery()
//        //        {
//        //            FirstName = "Ivan",
//        //            LastName = "Ivanov",
//        //            PhoneNumber = "0888888888",
//        //            PostCode = "1000",
//        //            Address = "bul. Vitosha",
//        //            Town = "Sofia",
//        //            District = "Sofia",
//        //            Country = "Bulgaria",
//        //            IsShippingToOffice = false,
//        //        }
//        //    };

//        //    // Act
//        //    string orderNumber = await _checkoutService.CheckoutSaveAsync(order, userId);
//        //    Order actual = _mockDbContext.Orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
//        //    IEnumerable<ProductsInBagDTO> actualProductInBag = await _productsService.GetProductsInBagAsync(userId);

//        //    // Assert
//        //    Assert.NotNull(actual);
//        //    Assert.IsTrue(actualProductInBag.Count() == 0);
//        //    Assert.AreEqual(expected.StatusOrderId, actual.StatusOrderId);
//        //    Assert.AreEqual(expected.PaymentMethodId, actual.PaymentMethodId);
//        //    Assert.AreEqual(expected.NoteForDelivery, actual.NoteForDelivery);
//        //    Assert.AreEqual(expected.PromoCodeId, actual.PromoCodeId);
//        //    Assert.AreEqual(expected.SubTotal, actual.SubTotal);
//        //    Assert.AreEqual(expected.Discount, actual.Discount);
//        //    Assert.AreEqual(expected.ShippingPrice, actual.ShippingPrice);
//        //    Assert.AreEqual(expected.Total, actual.Total);
//        //    Assert.AreEqual(expected.AddressDelivery.FirstName, actual.AddressDelivery.FirstName);
//        //    Assert.AreEqual(expected.AddressDelivery.LastName, actual.AddressDelivery.LastName);
//        //    Assert.AreEqual(expected.AddressDelivery.PhoneNumber, actual.AddressDelivery.PhoneNumber);
//        //    Assert.AreEqual(expected.AddressDelivery.PostCode, actual.AddressDelivery.PostCode);
//        //    Assert.AreEqual(expected.AddressDelivery.Address, actual.AddressDelivery.Address);
//        //    Assert.AreEqual(expected.AddressDelivery.Town, actual.AddressDelivery.Town);
//        //    Assert.AreEqual(expected.AddressDelivery.District, actual.AddressDelivery.District);
//        //    Assert.AreEqual(expected.AddressDelivery.Country, actual.AddressDelivery.Country);
//        //    Assert.AreEqual(expected.AddressDelivery.IsShippingToOffice, actual.AddressDelivery.IsShippingToOffice);
//        //    Assert.AreEqual(expected.ProductsOrders.Count, actual.ProductsOrders.Count);
//        //    for (int i = 0; i < expected.ProductsOrders.Count; i++)
//        //    {
//        //        Assert.AreEqual(expected.ProductsOrders[i].ProductId, actual.ProductsOrders[i].ProductId);
//        //        Assert.AreEqual(expected.ProductsOrders[i].Price, actual.ProductsOrders[i].Price);
//        //        Assert.AreEqual(expected.ProductsOrders[i].Quantity, actual.ProductsOrders[i].Quantity);
//        //        Assert.AreEqual(expected.ProductsOrders[i].ImagePath, actual.ProductsOrders[i].ImagePath);
//        //    }

//        //    ResetPromoCodes();
//        //    ResetBagsUsers();
//        //    ResetOrders();
//        //}


//        [Test]
//        public async Task OrderSummaryAsync_WhenCalled_ReturnOrderSummary()
//        {
//            // Arrange
//            OrderDTO order = new()
//            {
//                ProductsInBag =
//                [
//                    new ()
//                    {
//                        Id = 1,
//                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
//                        Price = 5.50m,
//                        Optional = "Тегло:  25 г.",
//                        Quantity = 3,
//                        ImageUrl = "/files/products/product-01-image-01.webp"
//                    },
//                    new ()
//                    {
//                        Id = 2,
//                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
//                        Price = 4.00m,
//                        Optional = "Тегло:  5 г.",
//                        Quantity = 4,
//                        ImageUrl = "/files/products/product-02-image-01.webp"
//                    }
//                ],
//                PaymentMethodId = 1,
//                PromoCodeId = 1,
//                PromoCodes =
//                [
//                    new ()
//                    {
//                        Id = 1,
//                        Code = "-10 % за регистрация",
//                        Discount = 0.1m,
//                        ExpirationDate = DateTime.UtcNow.AddMonths(12),
//                    },
//                    new ()
//                    {
//                        Id = 2,
//                        Code = "-20 % отстъпка",
//                        Discount = 0.2m,
//                        ExpirationDate = DateTime.UtcNow.AddMonths(12),
//                    },
//                ],
//                NoteForDelivery = "Some note",
//                IsValidOrder = true,
//                Address = new AddressDTO
//                {
//                    Id = 1,
//                    FirstName = "Ivan",
//                    LastName = "Ivanov",
//                    PhoneNumber = "0888888888",
//                    PostCode = "1000",
//                    Address = "bul. Vitosha",
//                    Town = "Sofia",
//                    District = "Sofia",
//                    Country = "Bulgaria",
//                }
//            };

//            OrderSummaryDTO expected = new()
//            {
//                FirstName = "Ivan",
//                LastName = "Ivanov",
//                PhoneNumber = "0888888888",
//                PostCode = "1000",
//                Address = "bul. Vitosha",
//                Town = "Sofia",
//                District = "Sofia",
//                Email = null,
//                Country = "Bulgaria",
//                IsShippingToOffice = false,
//                ShippingOfficeCity = null,
//                ShippingOfficeAddress = null,
//                ShippingProviderName = null,
//                PaymentMethod = "Наложен платеж",
//                NoteForDelivery = "Some note",
//                Products =
//                [
//                    new ()
//                    {
//                        Id = 1,
//                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
//                        Price = 5.50m,
//                        Quantity = 3,
//                        ImagePath = "/files/products/product-01-image-01.webp"
//                    },
//                    new ()
//                    {
//                        Id = 2,
//                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
//                        Price = 4.00m,
//                        Quantity = 4,
//                        ImagePath = "/files/products/product-02-image-01.webp"
//                    }
//                ],
//                SubTotal = 29.25m,
//                Discount = 3.25m,
//                ShippingPrice = 8m,
//                Total = 37.25m,
//                PromoCode = "-10 % за регистрация",
//            };

//            // Act
//            string orderNumber = await _checkoutService.CheckoutSaveAsync(order, userId);
//            OrderSummaryDTO actual = await _checkoutService.OrderSummaryAsync(orderNumber);

//            // Assert
//            Assert.NotNull(actual);
//            Assert.AreEqual(expected.FirstName, actual.FirstName);
//            Assert.AreEqual(expected.LastName, actual.LastName);
//            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
//            Assert.AreEqual(expected.PostCode, actual.PostCode);
//            Assert.AreEqual(expected.Address, actual.Address);
//            Assert.AreEqual(expected.Town, actual.Town);
//            Assert.AreEqual(expected.District, actual.District);
//            Assert.AreEqual(expected.Email, actual.Email);
//            Assert.AreEqual(expected.Country, actual.Country);
//            Assert.AreEqual(expected.IsShippingToOffice, actual.IsShippingToOffice);
//            Assert.AreEqual(expected.ShippingOfficeCity, actual.ShippingOfficeCity);
//            Assert.AreEqual(expected.ShippingOfficeAddress, actual.ShippingOfficeAddress);
//            Assert.AreEqual(expected.ShippingProviderName, actual.ShippingProviderName);
//            Assert.AreEqual(expected.PaymentMethod, actual.PaymentMethod);
//            Assert.AreEqual(expected.NoteForDelivery, actual.NoteForDelivery);
//            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
//            actual.Products = actual.Products.OrderBy(p => p.Id);
//            for (int i = 0; i < expected.Products.Count(); i++)
//            {
//                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
//                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
//                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
//                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
//                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
//            }
//            Assert.AreEqual(expected.SubTotal, actual.SubTotal);
//            Assert.AreEqual(expected.Discount, actual.Discount);
//            Assert.AreEqual(expected.ShippingPrice, actual.ShippingPrice);
//            Assert.AreEqual(expected.Total, actual.Total);
//            Assert.AreEqual(expected.PromoCode, actual.PromoCode);

//            ResetPromoCodes();
//            ResetBagsUsers();
//            ResetOrders();
//        }
//    }
//}
