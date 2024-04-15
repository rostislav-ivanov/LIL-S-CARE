using LilsCareApp.Core.Models.AdminProducts;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Tests.UnitTest
{
    public class AdminProductServiceTests : UnitTestsBase
    {
        private string userId;
        private AdminProductService _adminProductService;

        [SetUp]
        public void SetUp()
        {
            _adminProductService = new AdminProductService(_mockDbContext);
            userId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef";
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByNameAsc()
        {
            // Arrange
            var productSortType = ProductSortType.NameAsc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.NameAsc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }


        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByNameDesc()
        {
            // Arrange
            var productSortType = ProductSortType.NameDesc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.NameDesc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByIdAsc()
        {
            // Arrange
            var productSortType = ProductSortType.IdAsc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    }
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.IdAsc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByIdDesc()
        {
            // Arrange
            var productSortType = ProductSortType.IdDesc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.IdDesc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByPriceAsc()
        {
            // Arrange
            var productSortType = ProductSortType.PriceAsc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.PriceAsc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByPriceDesc()
        {
            // Arrange
            var productSortType = ProductSortType.PriceDesc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.PriceDesc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByQuantityAsc()
        {
            // Arrange
            var productSortType = ProductSortType.QuantityAsc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.QuantityAsc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByQuantityDesc()
        {
            // Arrange
            var productSortType = ProductSortType.QuantityDesc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.QuantityDesc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByIsShowAsc()
        {
            // Arrange
            var productSortType = ProductSortType.IsShowAsc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.IsShowAsc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSortedByIsShowDesc()
        {
            // Arrange
            var productSortType = ProductSortType.IsShowDesc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 5,
                        Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                        Price = 8.50m,
                        ImagePath = "/files/products/product-05-image-01.webp",
                        Quantity = 10,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 7,
                        Name = "",
                        Price = 10.00m,
                        ImagePath = null,
                        Quantity = 0,
                        IsShow = false,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.IsShowDesc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_ReturnsSearchProducts()
        {
            // Arrange
            var productSortType = ProductSortType.IdAsc;
            string search = "жожоба";
            int currentPage = 1;
            int productsPerPage = 10;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 6,
                        Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                        Price = 10.00m,
                        ImagePath = "/files/products/product-06-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                },
                TotalProductsCount = 3,
                ProductsPerPage = 10,
                CurrentPage = 1,
                ProductSortType = ProductSortType.IdAsc,
                Search = "жожоба",
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task GetProductsQueryAsync_WhenCalled_Returns3ProductsPerPage()
        {
            // Arrange
            var productSortType = ProductSortType.IdAsc;
            string search = null;
            int currentPage = 1;
            int productsPerPage = 3;

            AdminProductsDTO expected = new()
            {
                Products = new List<AdminProductDTO>()
                {
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        Quantity = 10,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                        Price = 4.00m,
                        ImagePath = "/files/products/product-02-image-01.webp",
                        Quantity = 20,
                        IsShow = true,
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                        Price = 12.00m,
                        ImagePath = "/files/products/product-03-image-01.webp",
                        Quantity = 30,
                        IsShow = true,
                    },
                },
                TotalProductsCount = 7,
                ProductsPerPage = 3,
                CurrentPage = 1,
                ProductSortType = ProductSortType.IdAsc,
            };

            // Act
            var actual = await _adminProductService.GetProductsQueryAsync(productSortType, search, currentPage, productsPerPage);

            // Assert
            Assert.IsInstanceOf<AdminProductsDTO>(actual);
            Assert.AreEqual(expected.Products.Count(), actual.Products.Count());
            Assert.AreEqual(expected.TotalProductsCount, actual.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, actual.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, actual.CurrentPage);
            Assert.AreEqual(expected.ProductSortType, actual.ProductSortType);
            Assert.AreEqual(expected.Search, actual.Search);
            for (int i = 0; i < expected.Products.Count(); i++)
            {
                Assert.AreEqual(expected.Products.ElementAt(i).Id, actual.Products.ElementAt(i).Id);
                Assert.AreEqual(expected.Products.ElementAt(i).Name, actual.Products.ElementAt(i).Name);
                Assert.AreEqual(expected.Products.ElementAt(i).Price, actual.Products.ElementAt(i).Price);
                Assert.AreEqual(expected.Products.ElementAt(i).Quantity, actual.Products.ElementAt(i).Quantity);
                Assert.AreEqual(expected.Products.ElementAt(i).ImagePath, actual.Products.ElementAt(i).ImagePath);
                Assert.AreEqual(expected.Products.ElementAt(i).IsShow, actual.Products.ElementAt(i).IsShow);
            }
        }

        [Test]
        public async Task ProductToShopAsync_WhenCalled_ShouldChangeIsShowFromFalseToTrue()
        {
            // Arrange
            Product product = _mockDbContext.Products.Find(7);
            Assert.IsFalse(product.IsShow);

            // Act
            await _adminProductService.ProductToShopAsync(7);

            // Assert
            Assert.IsTrue(product.IsShow);

            await _adminProductService.ProductToShopAsync(7);
        }

        [Test]
        public async Task ProductToShopAsync_WhenCalled_ShouldChangeIsShowFromTrueToFalse()
        {
            // Arrange
            Product product = _mockDbContext.Products.Find(1);
            Assert.IsTrue(product.IsShow);

            // Act
            await _adminProductService.ProductToShopAsync(1);

            // Assert
            Assert.IsFalse(product.IsShow);

            await _adminProductService.ProductToShopAsync(1);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteProductIfIsNotOrdered()
        {
            // Arrange
            Product product = _mockDbContext.Products.Find(7);
            Assert.IsNotNull(product);
            Assert.IsFalse(_mockDbContext.Orders.Any(o => o.ProductsOrders.Any(op => op.ProductId == 7)));

            // Act
            bool result = await _adminProductService.DeleteAsync(7);

            // Assert
            Assert.IsNull(_mockDbContext.Products.Find(7));
            Assert.IsTrue(result);

            ResetProducts();
            ResetImageProducts();
            ResetProductsOrders();
        }

        [Test]
        public async Task DeleteAsync_ShouldNotDeleteProductIfIsOrdered()
        {
            // Arrange
            Product product = _mockDbContext.Products.Find(1);
            Assert.IsNotNull(product);
            Assert.IsTrue(_mockDbContext.ProductsOrders.Any(po => po.ProductId == 1));

            // Act
            bool result = await _adminProductService.DeleteAsync(1);

            // Assert
            Assert.IsNotNull(_mockDbContext.Products.Find(1));
            Assert.IsFalse(result);

        }

        [Test]
        public async Task DeleteAsync_ShouldReturnFalseIfProductIdNotExist()
        {
            Assert.IsNull(_mockDbContext.Products.Find(100));
            // Act
            bool result = await _adminProductService.DeleteAsync(100);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
