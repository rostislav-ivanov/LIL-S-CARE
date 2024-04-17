using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.Products;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Tests.UnitTest
{
    [TestFixture]
    public class ProductsServiceTests : UnitTestsBase
    {
        private IProductsService _productsService;

        private string userId;


        [OneTimeSetUp]
        public void SetUp()
        {
            _productsService = new ProductsService(_mockDbContext);
            userId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef";
        }


        [Test]
        public async Task GetProductsQueryAsync_ShouldReturnAllProducts()
        {
            string? category = null;
            int currentPage = 1;
            int productsPerPage = 10;
            var resultProducts = await _productsService.GetProductsQueryAsync(userId, category, currentPage, productsPerPage);

            Assert.That(resultProducts.Products.Count(), Is.EqualTo(6));
            Assert.That(resultProducts.TotalProductsCount, Is.EqualTo(6));
            Assert.That(resultProducts.ProductsPerPage, Is.EqualTo(10));
            Assert.That(resultProducts.CurrentPage, Is.EqualTo(1));
            Assert.That(resultProducts.Categories.Count(), Is.EqualTo(5));
            Assert.That(resultProducts.Category, Is.EqualTo(null));
        }


        [Test]
        public async Task GetProductsQueryAsync_ShouldReturnProductsByCategory()
        {
            // Arrange
            ProductsDTO expected = new ProductsDTO()
            {
                Products =
                [
                    new ()
                    {
                        Id = 1,
                        Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                        Price = 5.50m,
                        ImageUrl = "/files/products/product-01-image-01.webp",
                        Quantity = 10,
                        IsWish = true,
                    },
                    new ()
                    {
                        Id = 4,
                        Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                        Price = 10.00m,
                        ImageUrl = "/files/products/product-04-image-01.webp",
                        Quantity = 0,
                        IsWish = true,
                    }
                ],
                TotalProductsCount = 2,
                ProductsPerPage = 10,
                CurrentPage = 1,
                Category = "за тяло",
                Categories =
                [
                    new () { Id = 1, Name = "всички" },
                    new () { Id = 2, Name = "за тяло" },
                    new () { Id = 3, Name = "за суха кожа" },
                    new () { Id = 4, Name = "за мазна кожа" },
                    new () { Id = 5, Name = "за лице" },
                ]
            };

            string? category = "за тяло";
            int currentPage = 1;
            int productsPerPage = 10;

            // Act
            var resultProducts = await _productsService.GetProductsQueryAsync(userId, category, currentPage, productsPerPage);

            // Assert
            Assert.AreEqual(expected.TotalProductsCount, resultProducts.TotalProductsCount);
            Assert.AreEqual(expected.ProductsPerPage, resultProducts.ProductsPerPage);
            Assert.AreEqual(expected.CurrentPage, resultProducts.CurrentPage);
            Assert.AreEqual(expected.Category, resultProducts.Category);
            Assert.AreEqual(expected.Products.Count(), resultProducts.Products.Count());
            foreach (var expectedProduct in expected.Products)
            {
                var actualProduct = resultProducts.Products.FirstOrDefault(p => p.Id == expectedProduct.Id);
                Assert.IsNotNull(actualProduct);
                Assert.AreEqual(expectedProduct.Name, actualProduct.Name);
                Assert.AreEqual(expectedProduct.Price, actualProduct.Price);
                Assert.AreEqual(expectedProduct.Quantity, actualProduct.Quantity);
                Assert.AreEqual(expectedProduct.ImageUrl, actualProduct.ImageUrl);
                Assert.AreEqual(expectedProduct.IsWish, actualProduct.IsWish);
                for (int i = 0; i < expected.Categories.Count; i++)
                {
                    Assert.AreEqual(expected.Categories[i].Id, resultProducts.Categories[i].Id);
                    Assert.AreEqual(expected.Categories[i].Name, resultProducts.Categories[i].Name);
                }

            }
            Assert.AreEqual(expected.Category.Count(), resultProducts.Category.Count());
        }


        [Test]
        public async Task GetProductsQueryAsync_ShouldReturnAllProductsWitchIsShow()
        {
            string? category = null;
            int currentPage = 1;
            int productsPerPage = 10;
            var resultProducts = await _productsService.GetProductsQueryAsync(userId, category, currentPage, productsPerPage);

            Assert.AreEqual(6, resultProducts.TotalProductsCount);
            foreach (var product in resultProducts.Products)
            {
                var actual = _mockDbContext.Products.FirstOrDefault(p => p.Id == product.Id);
                Assert.IsTrue(actual.IsShow);
            }
        }


        [Test]
        public async Task GetProductsQueryAsync_ShouldPaginateCorrectly()
        {
            string? category = null;
            int currentPage = 1;
            int productsPerPage = 2;
            var resultProducts = await _productsService.GetProductsQueryAsync(userId, category, currentPage, productsPerPage);

            Assert.That(resultProducts.Products.Count(), Is.EqualTo(2));
            Assert.That(resultProducts.TotalProductsCount, Is.EqualTo(6));
            Assert.That(resultProducts.ProductsPerPage, Is.EqualTo(2));
            Assert.That(resultProducts.CurrentPage, Is.EqualTo(1));
        }


        [Test]
        public async Task GetCategoriesAsync_ReturnsCorrectCategories()
        {
            // Arrange
            IEnumerable<CategoryDTO> expectedCategories =
            [
                new () { Id = 1, Name = "всички" },
                new () { Id = 2, Name = "за тяло" },
                new () { Id = 3, Name = "за суха кожа" },
                new () { Id = 4, Name = "за мазна кожа" },
                new () { Id = 5, Name = "за лице" }
            ];

            // Act
            var result = await _productsService.GetCategoriesAsync();

            // Assert
            Assert.AreEqual(expectedCategories.Count(), result.Count);

            foreach (var expectedCategory in expectedCategories)
            {
                var actualCategory = result.FirstOrDefault(c => c.Id == expectedCategory.Id);
                Assert.IsNotNull(actualCategory);
                Assert.AreEqual(expectedCategory.Name, actualCategory.Name);
            }
        }


        [Test]
        public async Task GetAllAsync_ReturnsCorrectProducts()
        {
            // Arrange
            IEnumerable<ProductDTO> expectedProducts =
            [
                new ()
                {
                    Id = 1,
                    Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                    Price = 5.50m,
                    ImageUrl = "/files/products/product-01-image-01.webp",
                    Quantity = 10,
                    IsWish = true,
                },
                new ()
                {
                    Id = 2,
                    Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                    Price = 4.00m,
                    ImageUrl = "/files/products/product-02-image-01.webp",
                    Quantity = 20,
                    IsWish = true,
                },
                new ()
                {
                    Id = 3,
                    Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                    Price = 12.00m,
                    ImageUrl = "/files/products/product-03-image-01.webp",
                    Quantity = 30,
                    IsWish = false,
                },
                new ()
                {
                    Id = 4,
                    Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                    Price = 10.00m,
                    ImageUrl = "/files/products/product-04-image-01.webp",
                    Quantity = 0,
                    IsWish = true,
                },
                new ()
                {
                    Id = 5,
                    Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                    Price = 8.50m,
                    ImageUrl = "/files/products/product-05-image-01.webp",
                    Quantity = 10,
                    IsWish = false,
                },
                new ProductDTO
                {
                    Id = 6,
                    Name = "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ",
                    Price = 10.00m,
                    ImageUrl = "/files/products/product-06-image-01.webp",
                    Quantity = 20,
                    IsWish = false,
                },
            ];

            // Act
            var result = await _productsService.GetAllAsync(userId);

            // Assert
            Assert.AreEqual(expectedProducts.Count(), result.Count());

            foreach (var expectedProduct in expectedProducts)
            {
                var actualProduct = result.FirstOrDefault(c => c.Id == expectedProduct.Id);
                Assert.IsNotNull(actualProduct);
                Assert.AreEqual(expectedProduct.Name, actualProduct.Name);
                Assert.AreEqual(expectedProduct.Price, actualProduct.Price);
                Assert.AreEqual(expectedProduct.Quantity, actualProduct.Quantity);
                Assert.AreEqual(expectedProduct.ImageUrl, actualProduct.ImageUrl);
                Assert.AreEqual(expectedProduct.IsWish, actualProduct.IsWish);

            }
        }


        [Test]
        public async Task AddRemoveWishAsync_WorkCorrectlyFromFalseToTrue()
        {
            // Arrange
            WishUser expected = new() { ProductId = 3, AppUserId = userId };

            // Act
            await _productsService.AddRemoveWishAsync(3, userId);
            var result = _mockDbContext.WishesUsers.FirstOrDefault(wu => wu.ProductId == 3 && wu.AppUserId == userId);

            // Assert
            Assert.AreEqual(result.ProductId, expected.ProductId);
            Assert.AreEqual(result.AppUserId, expected.AppUserId);

            ResetWishesUsers();
        }


        [Test]
        public async Task AddRemoveWishAsync_NotWorkIfProductNotExist()
        {
            // Arrange
            var expected = _mockDbContext.WishesUsers.Count();

            // Act
            await _productsService.AddRemoveWishAsync(10, userId);
            var result = _mockDbContext.WishesUsers.Count();

            // Assert
            Assert.AreEqual(expected, result);

            ResetWishesUsers();
        }

        [Test]
        public async Task AddRemoveWishAsync_NotWorkIfUserNotExist()
        {
            // Arrange
            var userId = "invalid-user-id";
            var expected = _mockDbContext.WishesUsers.Count();

            // Act
            await _productsService.AddRemoveWishAsync(1, userId);
            var result = _mockDbContext.WishesUsers.Count();

            // Assert
            Assert.AreEqual(expected, result);

            ResetWishesUsers();
        }

        [Test]
        public async Task GetProductsInBagAsync_WorkCorrectly()
        {
            // Arrange
            IEnumerable<ProductsInBagDTO> expected =
            [
                new ()
                {
                    Id = 1,
                    Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                    Optional = "Тегло:  25 г.",
                    Price = 5.50m,
                    ImageUrl = "/files/products/product-01-image-01.webp",
                    Quantity = 2,
                },
                new ()
                {
                    Id = 2,
                    Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                    Optional = "Тегло:  5 г.",
                    Price = 4.00m,
                    ImageUrl = "/files/products/product-02-image-01.webp",
                    Quantity = 3,
                },
                new ()
                {
                    Id = 3,
                    Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                    Optional = "Тегло:  50 г.",
                    Price = 12.00m,
                    ImageUrl = "/files/products/product-03-image-01.webp",
                    Quantity = 4,
                },
            ];


            // Act

            var result = await _productsService.GetProductsInBagAsync(userId);

            // Assert
            Assert.AreEqual(expected.Count(), result.Count());

            foreach (var expectedProduct in expected)
            {
                var actualProduct = result.FirstOrDefault(c => c.Id == expectedProduct.Id);
                Assert.IsNotNull(actualProduct);
                Assert.AreEqual(expectedProduct.Name, actualProduct.Name);
                Assert.AreEqual(expectedProduct.Optional, actualProduct.Optional);
                Assert.AreEqual(expectedProduct.Price, actualProduct.Price);
                Assert.AreEqual(expectedProduct.ImageUrl, actualProduct.ImageUrl);
                Assert.AreEqual(expectedProduct.Quantity, actualProduct.Quantity);

            }
        }


        [Test]
        public async Task AddToCartAsync_ShouldIncreaseQuantityWith2()
        {
            // Arrange
            int id = 2;
            int quantity = 2;

            var bagUser = _mockDbContext.BagsUsers.First(bu => bu.AppUserId == userId && bu.ProductId == id);
            var expected = bagUser.Quantity + quantity;

            // Act

            await _productsService.AddToCartAsync(id, userId, quantity);
            var result = _mockDbContext.BagsUsers.First(bu => bu.AppUserId == userId && bu.ProductId == id).Quantity;

            // Assert
            Assert.AreEqual(expected, result);

            ResetBagsUsers();
        }

        [Test]
        public async Task AddToCartAsync_ShouldDecreaseQuantityWith2()
        {
            // Arrange
            int id = 2;
            int quantity = -2;

            var bagUser = _mockDbContext.BagsUsers.First(bu => bu.AppUserId == userId && bu.ProductId == id);
            var expected = bagUser.Quantity + quantity;

            // Act

            await _productsService.AddToCartAsync(id, userId, quantity);
            var result = _mockDbContext.BagsUsers.First(bu => bu.AppUserId == userId && bu.ProductId == id).Quantity;

            // Assert
            Assert.AreEqual(expected, result);

            ResetBagsUsers();
        }

        [Test]
        public async Task AddToCartAsync_ShouldNotDecreaseQuantityWhenQuantityIsOne()
        {
            // Arrange
            int id = 2;
            int quantity = -1;

            var bagUser = _mockDbContext.BagsUsers.First(bu => bu.AppUserId == userId && bu.ProductId == id);
            bagUser.Quantity = 1;
            var expected = bagUser.Quantity;

            // Act

            await _productsService.AddToCartAsync(id, userId, quantity);
            var result = _mockDbContext.BagsUsers.First(bu => bu.AppUserId == userId && bu.ProductId == id).Quantity;

            // Assert
            Assert.AreEqual(expected, result);

            ResetBagsUsers();
        }

        [Test]
        public async Task AddToCartAsync_ShouldAddNewProductToUserBag()
        {
            // Arrange
            int id = 6;
            int quantity = 1;

            var bagUser = _mockDbContext.BagsUsers.FirstOrDefault(bu => bu.AppUserId == userId && bu.ProductId == id);

            // Assert
            Assert.IsNull(bagUser);

            // Act
            await _productsService.AddToCartAsync(id, userId, quantity);
            var result = _mockDbContext.BagsUsers.First(bu => bu.AppUserId == userId && bu.ProductId == id);

            // Assert
            Assert.AreEqual(1, result.Quantity);

            ResetBagsUsers();
        }

        [Test]
        public async Task DeleteProductFromCartAsync_ShouldWorkCorrectly()
        {
            // Arrange
            int id = 1;

            var bagUser = _mockDbContext.BagsUsers.FirstOrDefault(bu => bu.AppUserId == userId && bu.ProductId == id);

            // Assert
            Assert.IsNotNull(bagUser);

            // Act
            await _productsService.DeleteProductFromCartAsync(id, userId);
            var result = _mockDbContext.BagsUsers.FirstOrDefault(bu => bu.AppUserId == userId && bu.ProductId == id);

            // Assert
            Assert.IsNull(result);

            ResetBagsUsers();
        }

        [Test]
        public async Task GetCountInBagAsync_ShouldWorkCorrectly()
        {
            // Arrange
            var expected = 9;
            // Act
            var result = await _productsService.GetCountInBagAsync(userId);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task GetMyWishesAsync_ShouldWorkCorrectly()
        {
            IEnumerable<ProductDTO> expectedProducts =
            [
                new ()
                {
                    Id = 1,
                    Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                    Price = 5.50m,
                    ImageUrl = "/files/products/product-01-image-01.webp",
                    Quantity = 10,
                    IsWish = true,
                },
                new ()
                {
                    Id = 2,
                    Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                    Price = 4.00m,
                    ImageUrl = "/files/products/product-02-image-01.webp",
                    Quantity = 20,
                    IsWish = true,
                },
                new ()
                {
                    Id = 4,
                    Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                    Price = 10.00m,
                    ImageUrl = "/files/products/product-04-image-01.webp",
                    Quantity = 0,
                    IsWish = true,
                },
            ];

            // Act
            var result = await _productsService.GetMyWishesAsync(userId);

            // Assert
            Assert.AreEqual(expectedProducts.Count(), result.Count());

            foreach (var expectedProduct in expectedProducts)
            {
                var actualProduct = result.FirstOrDefault(c => c.Id == expectedProduct.Id);
                Assert.IsNotNull(actualProduct);
                Assert.AreEqual(expectedProduct.Name, actualProduct.Name);
                Assert.AreEqual(expectedProduct.Price, actualProduct.Price);
                Assert.AreEqual(expectedProduct.Quantity, actualProduct.Quantity);
                Assert.AreEqual(expectedProduct.ImageUrl, actualProduct.ImageUrl);
                Assert.AreEqual(expectedProduct.IsWish, actualProduct.IsWish);

            }
        }

        [Test]
        public async Task MigrateProductsInBagAsync_ShouldWorkCorrectly()
        {
            // Arrange
            IEnumerable<ProductsInBagDTO> productsInBag =
            [
                new ()
                {
                    Id = 1,
                    Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                    Price = 5.50m,
                    Quantity = 2,
                    Optional = "Тегло:  25 г.",
                },
                new ()
                {
                    Id = 2,
                    Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                    Price = 4.00m,
                    Optional = "Тегло:  5 г.",
                    Quantity = 3,
                }
            ];

            IEnumerable<BagUser> expected =
            [
                new () {ProductId = 1, AppUserId = userId, Quantity = 2},
                new () {ProductId = 2, AppUserId = userId, Quantity = 3},
            ];

            // Act
            await _productsService.MigrateProductsInBagAsync(userId, productsInBag);

            var result = _mockDbContext.BagsUsers.Where(bu => bu.AppUserId == userId);

            // Assert
            Assert.AreEqual(expected.Count(), result.Count());

            foreach (var expectedProduct in expected)
            {
                var actualProduct = result.FirstOrDefault(bu => bu.ProductId == expectedProduct.ProductId);
                Assert.IsNotNull(actualProduct);
                Assert.AreEqual(expectedProduct.AppUserId, actualProduct.AppUserId);
                Assert.AreEqual(expectedProduct.Quantity, actualProduct.Quantity);
            }

            ResetBagsUsers();
        }
    }
}

