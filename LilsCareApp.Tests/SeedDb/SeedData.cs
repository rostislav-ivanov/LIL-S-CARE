using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using static LilsCareApp.Infrastructure.DataConstants.AdminConstants;

namespace LilsCareApp.Tests.SeedDb
{
    public class SeedData
    {
        public IEnumerable<AddressDelivery> AddressDeliveries = new List<AddressDelivery>
        {
            new AddressDelivery
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "0888888888",
                PostCode = "1000",
                Address= "bul. Vitosha",
                Town = "Sofia",
                District = "Sofia",
                Country = "Bulgaria",
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
            new AddressDelivery
            {
                Id = 2,
                FirstName = "Petar",
                LastName = "Petrov",
                PhoneNumber = "0888888888",
                PostCode = "1000",
                Address= "bul. Vitosha",
                Town = "Sofia",
                District = "Sofia",
                Country = "Bulgaria",
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
        };



        public IEnumerable<AppUser> Users = new List<AppUser>()
        {
            new AppUser
            {
                Id = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG",
                Email = "test@softuni.bg",
                NormalizedEmail = "TEST@SOFTUNI.BG",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "Testov",
                ImagePath = "/files/users/test-testov.jpg",
                DefaultAddressDeliveryId = 1
            },
            new AppUser
            {
                Id = "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Adminov",
            }
        };

        public IEnumerable<IdentityRole> Roles =
        [
            new IdentityRole
            {
                Id = "1fad9b8a-7a81-4a37-90b1-2c47cefb9e0b",
                Name = AreaName,
                NormalizedName = AreaName.ToUpper(),
            }
        ];

        public IdentityUserRole<string> UserRole = new IdentityUserRole<string> { RoleId = "1fad9b8a-7a81-4a37-90b1-2c47cefb9e0b", UserId = "45fbe739-6be0-429d-b44b-1ce6cf7eeef" };


        public IEnumerable<BagUser> BagsUsers = new List<BagUser>
            {
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 1,
                    Quantity = 2
                },
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 2,
                    Quantity = 3
                },
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 3,
                    Quantity = 4
                },

            };


        public IEnumerable<Category> Categories =
        [
            new () { Id = 1, Name = "всички" },
            new () { Id = 2, Name = "за тяло" },
            new () { Id = 3, Name = "за суха кожа" },
            new () { Id = 4, Name = "за мазна кожа" },
            new () { Id = 5, Name = "за лице" },
        ];


        public IEnumerable<ImageProduct> Images = new List<ImageProduct>()
        {

                new ImageProduct
                {
                    Id = 1,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 2,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 3,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 4,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 5,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 6,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 7,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 8,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 9,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-05.webp",
                    ImageOrder = 5
                },
                new ImageProduct
                {
                    Id = 10,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 11,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 12,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 13,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 14,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-05.webp",
                    ImageOrder = 5
                },
                new ImageProduct
                {
                    Id = 15,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 16,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 17,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 18,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 19,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 20,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 21,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 22,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 23,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 24,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 25,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 26,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 27,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-05.webp",
                    ImageOrder = 5
                },

        };


        public IEnumerable<Order> Orders = new List<Order>
        {
           new Order
            {
                Id = 1,
                OrderNumber = "123456",
                CreatedOn = DateTime.ParseExact("28/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusOrderId = 1,
                AddressDeliveryId = 1,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                DateShipping = DateTime.ParseExact("29/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                TrackingNumber = "1234567890",
                PaymentMethodId = 1,
                ShippingPrice = 5.00m,
                SubTotal = 30.50m,
                Discount = 10.00m,
                Total = 20.50m,
            },
          new Order
             {
                Id = 2,
                OrderNumber = "123456x",
                CreatedOn = DateTime.ParseExact("25/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusOrderId = 2,
                AddressDeliveryId = 2,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                PaymentMethodId = 2,
                ShippingPrice = 5.00m,
                SubTotal = 22.50m,
                Discount = 0.00m,
                Total = 27.5m,
             },
        };



        public IEnumerable<PaymentMethod> PaymentMethods = new List<PaymentMethod>
        {
            new PaymentMethod { Id = 1, Type = "Наложен платеж" },
            new PaymentMethod { Id = 2, Type = "С карта" },
            new PaymentMethod { Id = 3, Type = "Банков превод" }
        };


        public IEnumerable<ProductCategory> ProductsCategories =
        [
            new () { ProductId = 1,CategoryId = 1},
            new () { ProductId = 2,CategoryId = 1},
            new () { ProductId = 3,CategoryId = 1},
            new () { ProductId = 4,CategoryId = 1},
            new () { ProductId = 5,CategoryId = 1},
            new () { ProductId = 6,CategoryId = 1},
            new () { ProductId = 1,CategoryId = 2},
            new () { ProductId = 1,CategoryId = 3},
            new () { ProductId = 2,CategoryId = 3},
            new () { ProductId = 2,CategoryId = 4},
            new () { ProductId = 3,CategoryId = 5},
            new () { ProductId = 4,CategoryId = 2},
            new () { ProductId = 4,CategoryId = 3},
            new () { ProductId = 4,CategoryId = 5},
            new () { ProductId = 5,CategoryId = 3},
            new () { ProductId = 5,CategoryId = 5},
            new () { ProductId = 6,CategoryId = 3},
            new () { ProductId = 6,CategoryId = 4},

        ];



        public IEnumerable<Product> Products =
        [
                new ()
                {
                    Id = 1,
                    NameId = 1,
                    Price = 5.50m,
                    Quantity = 10,
                    Optional = new ProductOptional//"Тегло:  25 г.",
                    {
                        OptionalEN = "Weight:  25 g.",
                        OptionalBG = "Тегло:  25 г.",
                        OptionalRO = "Greutate:  25 g.",
                    },
                    IsShow = true,
                },
                new ()
                {
                    Id = 2,
                    NameId = 2,
                    Price = 4.00m,
                    Optional = new ProductOptional //"Тегло:  5 г.",
                    {
                        OptionalEN = "Weight:  5 g.",
                        OptionalBG = "Тегло:  5 г.",
                        OptionalRO = "Greutate:  5 g.",
                    },
                    Quantity = 20,
                    IsShow = true,
                },
                new ()
                {
                    Id = 3,
                    NameId = 3,
                    Price = 12.00m,
                    Optional = new ProductOptional //"Тегло:  50 г.",
                    {
                        OptionalEN = "Weight:  50 g.",
                        OptionalBG = "Тегло:  50 г.",
                        OptionalRO = "Greutate:  50 g.",
                    },
                    Quantity = 30,
                    IsShow = true,
                },
                new ()
                {
                    Id = 4,
                    NameId = 4,
                    Price = 10.00m,
                    Optional = new ProductOptional //"Тегло:  100 мл.",
                    {
                        OptionalEN = "Weight:  100 ml.",
                        OptionalBG = "Тегло:  100 мл.",
                        OptionalRO = "Greutate:  100 ml.",
                    },
                    Quantity = 0,
                    IsShow = true,
                },
                new ()
                {
                    Id = 5,
                    NameId = 5,
                    Price = 8.50m,
                    Optional = new ProductOptional //"Тегло:  50 г.",
                    {
                        OptionalEN = "Weight:  50 g.",
                        OptionalBG = "Тегло:  50 г.",
                        OptionalRO = "Greutate:  50 g.",
                    },
                    Quantity = 10,
                    IsShow = true,
                },
                new ()
                {
                    Id = 6,
                    NameId = 6,
                    Price = 10.00m,
                    Optional = new ProductOptional //"Тегло:  20 мл.",
                    {
                        OptionalEN = "Weight:  20 ml.",
                        OptionalBG = "Тегло:  20 мл.",
                        OptionalRO = "Greutate:  20 ml.",
                    },
                    Quantity = 20,
                    IsShow = true,
                },
                new ()
                {
                    Id = 7,
                    NameId = 7,
                    Price = 10.00m,
                    Optional = new ProductOptional //"",
                    {
                        OptionalEN = "",
                        OptionalBG = "",
                        OptionalRO = "",
                    },
                    Quantity = 0,
                    IsShow = true,
                },

        ];


        public IEnumerable<ProductOrder> ProductsOrders =
            [
            new ()
            {
                ProductId = 1,
                OrderId = 1,
                Quantity = 2,
                ImagePath = "/files/products/product-01-image-01.webp",
                Price = 5.50m,
            },
            new ()
            {
                ProductId = 2,
                OrderId = 1,
                Quantity = 3,
                ImagePath = "/files/products/product-02-image-01.webp",
                Price = 6.50m,
            },
            new ()
            {
                ProductId = 2,
                OrderId = 2,
                Quantity = 3,
                ImagePath = "/files/products/product-02-image-01.webp",
                Price = 7.50m,
            },
        ];



        public IEnumerable<PromoCode> PromoCodes = new List<PromoCode>
        {
            new PromoCode
            {
                Id = 1,
                Code = "-10 % за регистрация",
                Discount = 0.1m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
            new PromoCode
            {
                Id = 2,
                Code = "-20 % отстъпка",
                Discount = 0.2m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
        };


        public IEnumerable<Review> Reviews = new List<Review>
        {
            new Review
            {
                Rating = 4,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.ParseExact("28/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                ProductId = 2,
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
            },
            new Review
            {
                Rating = 3,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 4,
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
            },
        };


        public IEnumerable<Section> Sections =
        [
            new ()
            {
                Id = 1,
                TitleId = 1,
                DescriptionId = 1,
                SectionOrder = 1,
                ProductId = 1
            },
            new ()
            {
                Id = 2,
                TitleId = 2,
                DescriptionId = 2,
                SectionOrder = 2,
                ProductId = 1
            },
            new ()
            {
                Id = 3,
                TitleId = 3,
                DescriptionId = 3,
                SectionOrder = 3,
                ProductId = 1
            },
            new ()
            {
                Id = 4,
                TitleId = 4,
                DescriptionId = 4,
                SectionOrder = 4,
                ProductId = 1
            },
            new ()
            {
                Id = 5,
                TitleId = 5,
                DescriptionId = 5,
                SectionOrder = 5,
                ProductId = 1
            },
            new ()
            {
                Id = 6,
                TitleId = 6,
                DescriptionId = 6,
                SectionOrder = 1,
                ProductId = 2
            },
            new ()
            {
                Id = 7,
                TitleId = 7,
                DescriptionId = 7,
                SectionOrder = 2,
                ProductId = 2
            },
            new ()
            {
                Id = 8,
                TitleId = 8,
                DescriptionId = 8,
                SectionOrder = 3,
                ProductId = 2
            },
            new ()
            {
                Id = 9,
                TitleId = 9,
                DescriptionId = 9,
                SectionOrder = 4,
                ProductId = 2
            },
            new ()
            {
                Id = 10,
                TitleId = 10,
                DescriptionId = 10,
                SectionOrder = 5,
                ProductId = 2
            },
            new ()
            {
                Id = 11,
                TitleId = 11,
                DescriptionId = 11,
                SectionOrder = 1,
                ProductId = 3
            },
            new ()
            {
                Id = 12,
                TitleId = 12,
                DescriptionId = 12,
                SectionOrder = 2,
                ProductId = 3
            },
            new ()
            {
                Id = 13,
                TitleId = 13,
                DescriptionId = 13,
                SectionOrder = 3,
                ProductId = 3
            },
            new ()
            {
                Id = 14,
                TitleId = 14,
                DescriptionId = 14,
                SectionOrder = 4,
                ProductId = 3
            },
            new ()
            {
                Id = 15,
                TitleId = 15,
                DescriptionId = 15,
                SectionOrder = 5,
                ProductId = 3
            }
            ,
            new ()
            {
                Id = 16,
                TitleId = 16,
                DescriptionId = 16,
                SectionOrder = 1,
                ProductId = 4
            },
            new ()
            {
                Id = 17,
                TitleId = 17,
                DescriptionId = 17,
                SectionOrder = 2,
                ProductId = 4
            },
            new ()
            {
                Id = 18,
                TitleId = 18,
                DescriptionId = 18,
                SectionOrder = 3,
                ProductId = 4
            },
            new ()
            {
                Id = 19,
                TitleId = 19,
                DescriptionId = 19,
                SectionOrder = 4,
                ProductId = 4
            },
            new ()
            {
                Id = 20,
                TitleId = 20,
                DescriptionId = 20,
                SectionOrder = 5,
                ProductId = 4
            }
            ,
            new ()
            {
                Id = 21,
                TitleId = 21,
                DescriptionId = 21,
                SectionOrder = 1,
                ProductId = 5
            },
            new ()
            {
                Id = 22,
                TitleId = 22,
                DescriptionId = 22,
                SectionOrder = 2,
                ProductId = 5
            },
            new ()
            {
                Id = 23,
                TitleId = 23,
                DescriptionId = 23,
                SectionOrder = 3,
                ProductId = 5
            },
            new ()
            {
                Id = 24,
                TitleId = 24,
                DescriptionId = 24,
                SectionOrder = 4,
                ProductId = 5
            },
            new ()
            {
                Id = 25,
                TitleId = 25,
                DescriptionId = 25,
                SectionOrder = 5,
                ProductId = 5
            },
            new ()
            {
                Id = 26,
                TitleId = 26,
                DescriptionId = 26,
                SectionOrder = 1,
                ProductId = 6
            },
            new ()
            {
                Id = 27,
                TitleId = 27,
                DescriptionId = 27,
                SectionOrder = 2,
                ProductId = 6
            },
            new ()
            {
                Id = 28,
                TitleId = 28,
                DescriptionId = 28,
                SectionOrder = 3,
                ProductId = 6
            },
            new ()
            {
                Id = 29,
                TitleId = 29,
                DescriptionId = 29,
                SectionOrder = 4,
                ProductId = 6
            },
            new ()
            {
                Id = 30,
                TitleId = 30,
                DescriptionId = 30,
                SectionOrder = 5,
                ProductId = 6
            },
            new ()
            {
                Id = 31,
                TitleId = 31,
                DescriptionId = 31,
                SectionOrder = 1,
                ProductId = 7
            },
            new ()
            {
                Id = 32,
                TitleId = 32,
                DescriptionId = 32,
                SectionOrder = 2,
                ProductId = 7
            },
            new ()
            {
                Id = 33,
                TitleId = 33,
                DescriptionId = 33,
                SectionOrder = 3,
                ProductId = 7
            },
            new ()
            {
                Id = 34,
                TitleId = 34,
                DescriptionId = 34,
                SectionOrder = 4,
                ProductId = 7
            },
            new ()
            {
                Id = 35,
                TitleId = 35,
                DescriptionId = 35,
                SectionOrder = 5,
                ProductId = 7
            }
        ];




        public IEnumerable<ShippingOffice> ShippingOffice = new List<ShippingOffice>
        {
            new ShippingOffice
            {
                Id = 1,
                City = "Sofia",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 2,
                City = "Sofia",
                OfficeAddress = "bul. Hristo Botev 20",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 3,
                City = "Varna",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 4,
                City = "Burgas",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 5,
                City = "Ruse",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 6,
                City = "Sofia",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 7,
                City = "Sofia",
                OfficeAddress = "bul. Hristo Botev 30",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 8,
                City = "Sofia",
                OfficeAddress = "bul. Bozveli 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 9,
                City = "Burgas",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 10,
                City = "Ruse",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            }

        };



        public IEnumerable<ShippingProvider> ShippingProviders = new List<ShippingProvider>
        {
            new ShippingProvider
            {
                Id = 1,
                Name = "Еконт",
            },
            new ShippingProvider
            {
                Id = 2,
                Name = "Спиди"
            },
        };


        public IEnumerable<StatusOrder> StatusOrders =
        [
            new () { Id = 1, Name = "Неизпълнена" },
            new () { Id = 2, Name = "Отменена" },
            new () { Id = 3, Name = "Изпълнена" },
            new () { Id = 4, Name = "Получена" },
            new () { Id = 5, Name = "Върната" },
        ];

        public IEnumerable<WishUser> WishesUsers = new List<WishUser>
            {
                new WishUser
                {
                    ProductId = 1,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                },
                new WishUser
                {
                    ProductId = 2,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                },
                new WishUser
                {
                    ProductId = 4,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                }
            };
    }
}
