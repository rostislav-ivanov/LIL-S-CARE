using LilsCareApp.Core.Models.Account;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data.Models;
using System.Globalization;

namespace LilsCareApp.Tests.UnitTest
{
    public class AccountServiceTests : UnitTestsBase
    {
        private string userId;
        private AccountService _accountService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _accountService = new AccountService(_mockDbContext);
            userId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef";
        }

        [Test]
        public async Task GetMyAccountAsync_WhenCalled_ReturnAccount()
        {
            // Arrange
            MyAddressDTO expected = new MyAddressDTO
            {
                UserName = "test@softuni.bg",
                FirstName = "Test",
                LastName = "Testov",
                Email = "test@softuni.bg",
                PhoneNumber = null,
                ImagePath = "/files/users/test-testov.jpg",
            };

            // Act
            var account = await _accountService.GetMyAccountAsync(userId);

            // Assert
            Assert.IsNotNull(account);
            Assert.AreEqual(expected.UserName, account.UserName);
            Assert.AreEqual(expected.FirstName, account.FirstName);
            Assert.AreEqual(expected.LastName, account.LastName);
            Assert.AreEqual(expected.Email, account.Email);
            Assert.AreEqual(expected.PhoneNumber, account.PhoneNumber);
            Assert.AreEqual(expected.ImagePath, account.ImagePath);
        }

        [Test]
        public async Task UpdateMyAccountAsync_WhenCalled_ReturnAccount()
        {
            // Arrange
            MyAddressDTO myNewAddress = new MyAddressDTO
            {
                UserName = "test@softuni2.bg",
                FirstName = "Test2",
                LastName = "Testov2",
                Email = "test@softuni2.bg",
                PhoneNumber = "888 123 456",
                ImagePath = "/files/users/test-testov2.jpg",
            };

            AppUser expected = new AppUser
            {
                UserName = "test@softuni.bg",
                FirstName = "Test2",
                LastName = "Testov2",
                Email = "test@softuni2.bg",
                PhoneNumber = "888 123 456",
                ImagePath = "/files/users/test-testov2.jpg",
            };

            // Act
            _accountService.UpdateMyAccountAsync(userId, myNewAddress);
            var actual = await _accountService.GetMyAccountAsync(userId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.UserName, actual.UserName);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.ImagePath, actual.ImagePath);

            ResetAddressDeliveries();
            ResetUsers();
        }

        [Test]
        public async Task GetUserImagePathAsync_WhenCalled_ReturnImagePath()
        {
            // Arrange
            string expected = "/files/users/test-testov.jpg";

            // Act
            var imagePath = await _accountService.GetUserImagePathAsync(userId);

            // Assert
            Assert.IsNotNull(imagePath);
            Assert.AreEqual(expected, imagePath);
        }

        [Test]
        public async Task GetMyOrdersAsync_WhenCalled_ReturnOrders()
        {
            // Arrange
            IEnumerable<MyOrderDTO> expected =
            [
               new ()
                {
                    Id = 1,
                    CreatedOn = DateTime.ParseExact("28/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    OrderNumber = "123456",
                    StatusOrder = "Неизпълнена",
                    Products =
                    [
                        new MyProductOrderDTO
                        {
                            ProductId = 1,
                            ProductName = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                            Quantity = 2,
                            ImagePath = "/files/products/product-01-image-01.webp",
                            Price = 5.50m,
                        },
                        new MyProductOrderDTO
                        {
                            ProductId = 2,
                            ProductName = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                            Quantity = 3,
                            ImagePath = "/files/products/product-02-image-01.webp",
                            Price = 6.50m,
                        },
                    ],
                    DateShipping = DateTime.ParseExact("29/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TrackingNumber = "1234567890",
                    ShippingPrice = 5.00m,
                    SubTotal = 30.50m,
                    Discount = 10.00m,
                    Total = 20.50m,
                },
                new ()
                {
                    Id = 2,
                    OrderNumber = "123456x",
                    CreatedOn = DateTime.ParseExact("25/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    StatusOrder = "Отменена",
                    Products =
                    [
                        new MyProductOrderDTO
                        {
                            ProductId = 2,
                            ProductName = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                            Quantity = 3,
                            ImagePath = "/files/products/product-02-image-01.webp",
                            Price = 7.50m,
                        },
                    ],
                    ShippingPrice = 5.00m,
                    SubTotal = 22.50m,
                    Discount = 0.00m,
                    Total = 27.5m,
                }
            ];

            // Act
            var actual = await _accountService.GetMyOrdersAsync(userId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.AreEqual(expected.First().Id, actual.First().Id);
            Assert.AreEqual(expected.First().OrderNumber, actual.First().OrderNumber);
            Assert.AreEqual(expected.First().StatusOrder, actual.First().StatusOrder);
            Assert.AreEqual(expected.First().Products.Count(), actual.First().Products.Count());
            Assert.AreEqual(expected.First().DateShipping, actual.First().DateShipping);
            Assert.AreEqual(expected.First().TrackingNumber, actual.First().TrackingNumber);
            Assert.AreEqual(expected.First().ShippingPrice, actual.First().ShippingPrice);
            Assert.AreEqual(expected.First().SubTotal, actual.First().SubTotal);
            Assert.AreEqual(expected.First().Discount, actual.First().Discount);
            Assert.AreEqual(expected.First().Total, actual.First().Total);
            for (int i = 0; i < expected.First().Products.Count(); i++)
            {
                Assert.AreEqual(expected.First().Products.ElementAt(i).ProductId, actual.First().Products.ElementAt(i).ProductId);
                Assert.AreEqual(expected.First().Products.ElementAt(i).ProductName, actual.First().Products.ElementAt(i).ProductName);
                Assert.AreEqual(expected.First().Products.ElementAt(i).Quantity, actual.First().Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.First().Products.ElementAt(i).ImagePath, actual.First().Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.First().Products.ElementAt(i).Price, actual.First().Products.ElementAt(i).Price);
            };
            Assert.AreEqual(expected.Last().Id, actual.Last().Id);
            Assert.AreEqual(expected.Last().OrderNumber, actual.Last().OrderNumber);
            Assert.AreEqual(expected.Last().StatusOrder, actual.Last().StatusOrder);
            Assert.AreEqual(expected.Last().Products.Count(), actual.Last().Products.Count());
            Assert.AreEqual(expected.Last().ShippingPrice, actual.Last().ShippingPrice);
            Assert.AreEqual(expected.Last().SubTotal, actual.Last().SubTotal);
            Assert.AreEqual(expected.Last().Discount, actual.Last().Discount);
            Assert.AreEqual(expected.Last().Total, actual.Last().Total);
            for (int i = 0; i < expected.Last().Products.Count(); i++)
            {
                Assert.AreEqual(expected.Last().Products.ElementAt(i).ProductId, actual.Last().Products.ElementAt(i).ProductId);
                Assert.AreEqual(expected.Last().Products.ElementAt(i).ProductName, actual.Last().Products.ElementAt(i).ProductName);
                Assert.AreEqual(expected.Last().Products.ElementAt(i).Quantity, actual.Last().Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Last().Products.ElementAt(i).ImagePath, actual.Last().Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Last().Products.ElementAt(i).Price, actual.Last().Products.ElementAt(i).Price);
            };
        }

        [Test]
        public async Task GetMyAddressesAsync_WhenCalled_ReturnAddresses()
        {
            // Arrange
            IEnumerable<DeliveryAddressDTO> expected =
            [
                new ()
                {
                    AddressId = 1,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    PhoneNumber = "0888888888",
                    PostCode = "1000",
                    Address= "bul. Vitosha",
                    Town = "Sofia",
                    District = "Sofia",
                    Country = "Bulgaria",
                    Email = null,
                    ShippingProvider = null,
                    OfficeCity = null,
                    OfficeAddress = null,
                    IsDefault = true,
                    IsOffice = false,
                },
                new ()
                {
                    AddressId = 2,
                    FirstName = "Petar",
                    LastName = "Petrov",
                    PhoneNumber = "0888888888",
                    PostCode = "1000",
                    Address= "bul. Vitosha",
                    Town = "Sofia",
                    District = "Sofia",
                    Country = "Bulgaria",
                    Email = null,
                    ShippingProvider = null,
                    OfficeCity = null,
                    OfficeAddress = null,
                    IsDefault = false,
                    IsOffice = false,
                },
            ];

            // Act
            var actual = await _accountService.GetMyAddressesAsync(userId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).AddressId, actual.ElementAt(i).AddressId);
                Assert.AreEqual(expected.ElementAt(i).FirstName, actual.ElementAt(i).FirstName);
                Assert.AreEqual(expected.ElementAt(i).LastName, actual.ElementAt(i).LastName);
                Assert.AreEqual(expected.ElementAt(i).PhoneNumber, actual.ElementAt(i).PhoneNumber);
                Assert.AreEqual(expected.ElementAt(i).PostCode, actual.ElementAt(i).PostCode);
                Assert.AreEqual(expected.ElementAt(i).Address, actual.ElementAt(i).Address);
                Assert.AreEqual(expected.ElementAt(i).Town, actual.ElementAt(i).Town);
                Assert.AreEqual(expected.ElementAt(i).District, actual.ElementAt(i).District);
                Assert.AreEqual(expected.ElementAt(i).Country, actual.ElementAt(i).Country);
                Assert.AreEqual(expected.ElementAt(i).Email, actual.ElementAt(i).Email);
                Assert.AreEqual(expected.ElementAt(i).ShippingProvider, actual.ElementAt(i).ShippingProvider);
                Assert.AreEqual(expected.ElementAt(i).OfficeCity, actual.ElementAt(i).OfficeCity);
                Assert.AreEqual(expected.ElementAt(i).OfficeAddress, actual.ElementAt(i).OfficeAddress);
                Assert.AreEqual(expected.ElementAt(i).IsDefault, actual.ElementAt(i).IsDefault);
                Assert.AreEqual(expected.ElementAt(i).IsOffice, actual.ElementAt(i).IsOffice);
            };
        }

        [Test]
        public async Task RemoveAddressFromAppUserAsync_WhenCalled_RemoveAddressesFormUser()
        {
            // Arrange
            var appUser = _mockDbContext.Users.FirstOrDefault(u => u.Id == userId);
            var address = _mockDbContext.AddressDeliveries.FirstOrDefault(a => a.Id == 1);

            Assert.IsNotNull(appUser.DefaultAddressDelivery);
            Assert.IsNotNull(address);

            // Act
            await _accountService.RemoveAddressFromAppUserAsync(1);
            var actual = _mockDbContext.AddressDeliveries.FirstOrDefault(a => a.Id == 1);

            // Assert
            Assert.IsNull(actual.AppUser);
            Assert.IsNull(appUser.DefaultAddressDelivery);

            ResetAddressDeliveries();
            ResetUsers();
        }

        [Test]
        public async Task SetDefaultAddressAsync_WhenCalled_ChangeAddressDelivery()
        {
            // Arrange
            var appUser = _mockDbContext.Users.FirstOrDefault(u => u.Id == userId);

            Assert.AreEqual(1, appUser.DefaultAddressDeliveryId);
            Assert.AreNotEqual(2, appUser.DefaultAddressDeliveryId);

            // Act
            await _accountService.SetDefaultAddressAsync(userId, 2);

            // Assert
            Assert.AreNotEqual(1, appUser.DefaultAddressDeliveryId);
            Assert.AreEqual(2, appUser.DefaultAddressDeliveryId);

            ResetAddressDeliveries();
            ResetUsers();
        }

        [Test]
        public async Task GetShippingProvidersAsync_WhenCalled_ReturnShippingProviders()
        {
            // Arrange
            IEnumerable<ShippingProviderDTO> expected =
            [
                new ()
                {
                    Id = 1,
                    Name = "Еконт",
                    Description = "",
                },
                new ()
                {
                    Id = 2,
                    Name = "Спиди",
                    Description = "",
                },
            ];

            // Act
            var actual = await _accountService.GetShippingProvidersAsync();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
                Assert.AreEqual(expected.ElementAt(i).Name, actual.ElementAt(i).Name);
                Assert.AreEqual(expected.ElementAt(i).Description, actual.ElementAt(i).Description);
            };
        }

        [Test]
        public async Task GetShippingProviderCitiesAsync_WhenCalled_ReturnShippingProviderCities()
        {
            // Arrange
            IEnumerable<string> expected = ["Burgas", "Ruse", "Sofia", "Varna"];

            // Act
            var actual = await _accountService.GetShippingProviderCitiesAsync(1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i), actual.ElementAt(i));
            };
        }

        [Test]
        public async Task GetShippingOfficesAsync_WhenCalled_ReturnShippingOffices()
        {
            // Arrange
            IEnumerable<ShippingOfficeDTO> expected =
            [
                new ()
                {
                    Id = 1,
                    City = "Sofia",
                    OfficeAddress = "bul. Vitosha 100",
                    Price = 5.00m,
                    ShippingDuration = 2,
                },
                new ()
                {
                    Id = 2,
                    City = "Sofia",
                    OfficeAddress = "bul. Hristo Botev 20",
                    Price = 5.00m,
                    ShippingDuration = 2,
                },
            ];

            // Act
            var actual = await _accountService.GetShippingOfficesAsync(1, "Sofia");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
                Assert.AreEqual(expected.ElementAt(i).City, actual.ElementAt(i).City);
                Assert.AreEqual(expected.ElementAt(i).OfficeAddress, actual.ElementAt(i).OfficeAddress);
                Assert.AreEqual(expected.ElementAt(i).Price, actual.ElementAt(i).Price);
                Assert.AreEqual(expected.ElementAt(i).ShippingDuration, actual.ElementAt(i).ShippingDuration);
            };
        }

        [Test]
        public async Task GetAddressDeliveryAsync_WhenCalled_ReturnAddressDelivery()
        {
            // Arrange
            DeliveryAddressesDTO expected = new()
            {
                Address = new AddressDTO
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    PhoneNumber = "0888888888",
                    PostCode = "1000",
                    Address = "bul. Vitosha",
                    Town = "Sofia",
                    District = "Sofia",
                    Country = "Bulgaria",
                    Email = "",
                },
                Office = null,
            };

            // Act
            var actual = await _accountService.GetAddressDeliveryAsync(1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Address.FirstName, actual.Address.FirstName);
            Assert.AreEqual(expected.Address.LastName, actual.Address.LastName);
            Assert.AreEqual(expected.Address.PhoneNumber, actual.Address.PhoneNumber);
            Assert.AreEqual(expected.Address.PostCode, actual.Address.PostCode);
            Assert.AreEqual(expected.Address.Address, actual.Address.Address);
            Assert.AreEqual(expected.Address.Town, actual.Address.Town);
            Assert.AreEqual(expected.Address.District, actual.Address.District);
            Assert.AreEqual(expected.Address.Country, actual.Address.Country);
            Assert.AreEqual(expected.Address.Email, actual.Address.Email);
            Assert.IsNull(actual.Office);
            Assert.IsTrue(actual.IsSelectedDeliveryType());
            Assert.AreEqual(expected.DeliveryType(), actual.AddressDeliveryType);
        }
    }
}
