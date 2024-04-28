//using LilsCareApp.Core.Contracts;
//using LilsCareApp.Core.Models.Account;
//using LilsCareApp.Core.Models.Checkout;
//using LilsCareApp.Core.Models.GuestUser;
//using LilsCareApp.Core.Services;
//using LilsCareApp.Infrastructure.Data.Models;
//using Moq;

//namespace LilsCareApp.Tests.UnitTest
//{
//    public class GuestServiceTests : UnitTestsBase
//    {
//        private IGuestService _guestService;

//        private string userId;

//        [SetUp]
//        public void SetUp()
//        {
//            var sessionManagerMock = new Mock<IGuestSessionManager>();
//            sessionManagerMock.Setup(m => m.GetSession()).Returns(new GuestSession());
//            sessionManagerMock.Setup(m => m.SetSession(It.IsAny<GuestSession>()));
//            _guestService = new GuestService(sessionManagerMock.Object, _mockDbContext);
//        }

//        [Test]
//        public void AddToCart_ShouldAddProductToCartToEmptyCard()
//        {
//            // Arrange
//            var productId = 1;
//            var quantity = 1;

//            // Act
//            _guestService.AddToCart(productId, quantity);

//            // Assert
//            var session = _guestService.GetSession();
//            Assert.NotNull(session);
//            Assert.AreEqual(1, session.GuestBags.Count);
//            Assert.AreEqual(productId, session.GuestBags[0].ProductId);
//            Assert.AreEqual(quantity, session.GuestBags[0].Quantity);
//        }

//        [Test]
//        public void AddToCart_ShouldAddProductToCartToNonEmptyCard()
//        {
//            // Arrange
//            var productId = 1;
//            var quantity = 1;

//            // Act
//            _guestService.AddToCart(productId, quantity);
//            _guestService.AddToCart(productId, quantity);

//            // Assert
//            var session = _guestService.GetSession();
//            Assert.NotNull(session);
//            Assert.AreEqual(1, session.GuestBags.Count);
//            Assert.AreEqual(productId, session.GuestBags[0].ProductId);
//            Assert.AreEqual(2, session.GuestBags[0].Quantity);
//        }

//        [Test]
//        public void DeleteProductFromCart_ShouldDeleteProductFromCart()
//        {
//            // Arrange
//            var productId = 1;
//            var quantity = 1;

//            // Act
//            _guestService.AddToCart(productId, quantity);
//            _guestService.DeleteProductFromCart(productId);

//            // Assert
//            var session = _guestService.GetSession();
//            Assert.NotNull(session);
//            Assert.AreEqual(0, session.GuestBags.Count);
//        }

//        [Test]
//        public void GetCountInBag_ShouldReturnTotalNumberOfProductsInBag()
//        {
//            // Arrange
//            var productId = 1;
//            var quantity = 1;

//            // Act
//            _guestService.AddToCart(productId, quantity);
//            _guestService.AddToCart(productId, quantity);

//            // Assert
//            var count = _guestService.GetCountInBag();
//            Assert.AreEqual(2, count);
//        }

//        [Test]
//        public void GetProductsInBagAsync_ShouldReturnProductsInBag()
//        {
//            // Arrange
//            IEnumerable<ProductsInBagDTO> productsInBagDTOs =
//            [
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
//            ];
//            // Act
//            _guestService.AddToCart(1, 3);
//            _guestService.AddToCart(2, 4);

//            // Assert
//            var products = _guestService.GetProductsInBagAsync().Result;
//            Assert.NotNull(products);
//            Assert.AreEqual(productsInBagDTOs.Count(), products.Count());
//            Assert.AreEqual(productsInBagDTOs.First().Id, products.First().Id);
//            Assert.AreEqual(productsInBagDTOs.First().Name, products.First().Name);
//            Assert.AreEqual(productsInBagDTOs.First().Price, products.First().Price);
//            Assert.AreEqual(productsInBagDTOs.First().Optional, products.First().Optional);
//            Assert.AreEqual(productsInBagDTOs.First().Quantity, products.First().Quantity);
//            Assert.AreEqual(productsInBagDTOs.First().ImageUrl, products.First().ImageUrl);
//            Assert.AreEqual(productsInBagDTOs.Last().Id, products.Last().Id);
//            Assert.AreEqual(productsInBagDTOs.Last().Name, products.Last().Name);
//            Assert.AreEqual(productsInBagDTOs.Last().Price, products.Last().Price);
//            Assert.AreEqual(productsInBagDTOs.Last().Optional, products.Last().Optional);
//            Assert.AreEqual(productsInBagDTOs.Last().Quantity, products.Last().Quantity);
//            Assert.AreEqual(productsInBagDTOs.Last().ImageUrl, products.Last().ImageUrl);
//        }

//        [Test]
//        public async Task CheckoutSaveAsync_ShouldSaveOrder()
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

//            Order expected = new()
//            {
//                StatusOrderId = 1,
//                PaymentMethodId = 1,
//                NoteForDelivery = "Some note",
//                ProductsOrders =
//                [
//                    new ()
//                    {
//                        ProductId = 1,
//                        Price = 5.50m,
//                        Quantity = 3,
//                        ImagePath = "/files/products/product-01-image-01.webp"
//                    },
//                    new ()
//                    {
//                        ProductId = 2,
//                        Price = 4.00m,
//                        Quantity = 4,
//                        ImagePath = "/files/products/product-02-image-01.webp"
//                    }
//                ],
//                PromoCodeId = 1,
//                SubTotal = 29.25m,
//                Discount = 3.25m,
//                ShippingPrice = 8m,
//                Total = 37.25m,
//                AddressDelivery = new AddressDelivery()
//                {
//                    FirstName = "Ivan",
//                    LastName = "Ivanov",
//                    PhoneNumber = "0888888888",
//                    PostCode = "1000",
//                    Address = "bul. Vitosha",
//                    Town = "Sofia",
//                    District = "Sofia",
//                    Country = "Bulgaria",
//                    IsShippingToOffice = false,
//                }
//            };

//            string orderNumber = await _guestService.CheckoutSaveAsync(order);
//            Order actual = _mockDbContext.Orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
//            IEnumerable<ProductsInBagDTO> actualProductInBag = await _guestService.GetProductsInBagAsync();

//            Assert.NotNull(actual);
//            Assert.IsTrue(actualProductInBag.Count() == 0);
//            Assert.AreEqual(expected.StatusOrderId, actual.StatusOrderId);
//            Assert.AreEqual(expected.PaymentMethodId, actual.PaymentMethodId);
//            Assert.AreEqual(expected.NoteForDelivery, actual.NoteForDelivery);
//            Assert.AreEqual(expected.PromoCodeId, actual.PromoCodeId);
//            Assert.AreEqual(expected.SubTotal, actual.SubTotal);
//            Assert.AreEqual(expected.Discount, actual.Discount);
//            Assert.AreEqual(expected.ShippingPrice, actual.ShippingPrice);
//            Assert.AreEqual(expected.Total, actual.Total);
//            Assert.AreEqual(expected.AddressDelivery.FirstName, actual.AddressDelivery.FirstName);
//            Assert.AreEqual(expected.AddressDelivery.LastName, actual.AddressDelivery.LastName);
//            Assert.AreEqual(expected.AddressDelivery.PhoneNumber, actual.AddressDelivery.PhoneNumber);
//            Assert.AreEqual(expected.AddressDelivery.PostCode, actual.AddressDelivery.PostCode);
//            Assert.AreEqual(expected.AddressDelivery.Address, actual.AddressDelivery.Address);
//            Assert.AreEqual(expected.AddressDelivery.Town, actual.AddressDelivery.Town);
//            Assert.AreEqual(expected.AddressDelivery.District, actual.AddressDelivery.District);
//            Assert.AreEqual(expected.AddressDelivery.Country, actual.AddressDelivery.Country);
//            Assert.AreEqual(expected.AddressDelivery.IsShippingToOffice, actual.AddressDelivery.IsShippingToOffice);
//            Assert.AreEqual(expected.ProductsOrders.Count, actual.ProductsOrders.Count);
//            for (int i = 0; i < expected.ProductsOrders.Count; i++)
//            {
//                Assert.AreEqual(expected.ProductsOrders[i].ProductId, actual.ProductsOrders[i].ProductId);
//                Assert.AreEqual(expected.ProductsOrders[i].Price, actual.ProductsOrders[i].Price);
//                Assert.AreEqual(expected.ProductsOrders[i].Quantity, actual.ProductsOrders[i].Quantity);
//                Assert.AreEqual(expected.ProductsOrders[i].ImagePath, actual.ProductsOrders[i].ImagePath);
//            }

//        }
//    }
//}
