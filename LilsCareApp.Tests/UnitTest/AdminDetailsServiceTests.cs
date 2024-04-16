using LilsCareApp.Core.Models.AdminProducts;
using LilsCareApp.Core.Models.Products;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Tests.UnitTest
{
    public class AdminDetailsServiceTests : UnitTestsBase
    {
        private string userId;
        private AdminDetailsService _adminDetailsService;

        [SetUp]
        public void SetUp()
        {
            _adminDetailsService = new AdminDetailsService(_mockDbContext);
            userId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef";
        }

        [Test]
        public async Task GetProductByIdAsync_ReturnsAdminDetails()
        {
            // Arrange
            AdminDetailsDTO expected = new()
            {
                Id = 1,
                Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                Price = 5.50m,
                AvailableQuantity = 10,
                Optional = "Тегло:  25 г.",
                Sections =
                [
                    new ()
                    {
                        Id = 1,
                        Title = "ОПИСАНИЕ",
                        Description = "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био",
                        SectionOrder = 1,
                    },
                    new ()
                    {
                        Id = 2,
                        Title = "ЗА СЪСТАВКИТЕ",
                        Description = "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.",
                        SectionOrder = 2,
                    },
                    new ()
                    {
                        Id = 3,
                        Title = "УПОТРЕБА",
                        Description = "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.",
                        SectionOrder = 3,
                    },
                    new ()
                    {
                        Id = 4,
                        Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                        Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                        SectionOrder = 4,
                    },
                    new ()
                    {
                        Id = 5,
                        Title = "СЪСТАВ, INCI",
                        Description = "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio",
                        SectionOrder = 5,
                    }
                ],
                Images =
                [
                    new ()
                    {
                        Id = 1,
                        ImagePath = "/files/products/product-01-image-01.webp",
                        ImageOrder = 1,
                        IsVideo = false
                    },
                    new ()
                    {
                        Id = 2,
                        ImagePath = "/files/products/product-01-image-02.webp",
                        ImageOrder = 2,
                        IsVideo = false
                    },
                    new ()
                    {
                        Id = 3,
                        ImagePath = "/files/products/product-01-image-03.webp",
                        ImageOrder = 3,
                        IsVideo = false
                    },
                    new ()
                    {
                        Id = 4,
                        ImagePath = "/files/products/product-01-image-04.webp",
                        ImageOrder = 4,
                        IsVideo = false
                    }
                ],
                ProductsCategories =
                [
                    new ()
                    {
                        Id = 1,
                        Name = "всички",
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "за тяло",
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "за суха кожа",
                    }
                ],
            };

            // Act
            var actual = await _adminDetailsService.GetProductByIdAsync(1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.AvailableQuantity, actual.AvailableQuantity);
            Assert.AreEqual(expected.Optional, actual.Optional);
            Assert.AreEqual(expected.Sections.Count, actual.Sections.Count);
            for (int i = 0; i < expected.Sections.Count; i++)
            {
                Assert.AreEqual(expected.Sections[i].Id, actual.Sections[i].Id);
                Assert.AreEqual(expected.Sections[i].Title, actual.Sections[i].Title);
                Assert.AreEqual(expected.Sections[i].Description, actual.Sections[i].Description);
                Assert.AreEqual(expected.Sections[i].SectionOrder, actual.Sections[i].SectionOrder);
            };
            Assert.AreEqual(expected.Images.Count, actual.Images.Count);
            for (int i = 0; i < expected.Images.Count; i++)
            {
                Assert.AreEqual(expected.Images[i].Id, actual.Images[i].Id);
                Assert.AreEqual(expected.Images[i].ImagePath, actual.Images[i].ImagePath);
                Assert.AreEqual(expected.Images[i].ImageOrder, actual.Images[i].ImageOrder);
                Assert.AreEqual(expected.Images[i].IsVideo, actual.Images[i].IsVideo);
            };
            Assert.AreEqual(expected.ProductsCategories.Count, actual.ProductsCategories.Count);
            for (int i = 0; i < expected.ProductsCategories.Count; i++)
            {
                Assert.AreEqual(expected.ProductsCategories[i].Id, actual.ProductsCategories[i].Id);
                Assert.AreEqual(expected.ProductsCategories[i].Name, actual.ProductsCategories[i].Name);
            };
        }

        [Test]
        public async Task GetProductByIdAsync_WhenProductDoesNotExist_ReturnsNull()
        {
            // Act
            var actual = await _adminDetailsService.GetProductByIdAsync(100);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public async Task GetCategoriesAsync_ReturnsCategories()
        {
            // Arrange
            IEnumerable<CategoryDTO> expected =
            [
                new ()
                {
                    Id = 1,
                    Name = "всички",
                },
                new ()
                {
                    Id = 2,
                    Name = "за тяло",
                },
                new ()
                {
                    Id = 3,
                    Name = "за суха кожа",
                },
                new ()
                {
                    Id = 4,
                    Name = "за мазна кожа",
                },
                new ()
                {
                    Id = 5,
                    Name = "за лице",
                },
            ];

            // Act
            var actual = await _adminDetailsService.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ToList()[i].Id, actual.ToList()[i].Id);
                Assert.AreEqual(expected.ToList()[i].Name, actual.ToList()[i].Name);
            };
        }

        [Test]
        public async Task CreateProductAsync()
        {
            // Arrange
            AdminDetailsDTO expected = new()
            {
                Name = "Нов продукт",
                Price = 0,
                Quantity = 0,
                Optional = "",
                Sections = [],
                ProductsCategories = []
            };

            var listProductsIds = _mockDbContext.Products.Select(p => p.Id).ToList();

            // Act
            var actual = await _adminDetailsService.CreateProductAsync();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.AvailableQuantity, actual.AvailableQuantity);
            Assert.AreEqual(expected.Optional, actual.Optional);
            Assert.AreEqual(expected.Sections.Count, actual.Sections.Count);
            Assert.AreEqual(expected.ProductsCategories.Count, actual.ProductsCategories.Count);
            Assert.IsFalse(listProductsIds.Contains(actual.Id));

            // Clean up
            _mockDbContext.Products.Remove(_mockDbContext.Products.Find(actual.Id));
        }

        [Test]
        public async Task CreateProductByTemplateAsync()
        {
            // Arrange
            AdminDetailsDTO expected = new()
            {
                Name = "Нов продукт",
                Price = 5.50m,
                AvailableQuantity = 0,
                Optional = "Тегло:  25 г.",
                Sections =
                [
                    new ()
                    {
                        Id = 1,
                        Title = "ОПИСАНИЕ",
                        Description = "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био",
                        SectionOrder = 1,
                    },
                    new ()
                    {
                        Id = 2,
                        Title = "ЗА СЪСТАВКИТЕ",
                        Description = "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.",
                        SectionOrder = 2,
                    },
                    new ()
                    {
                        Id = 3,
                        Title = "УПОТРЕБА",
                        Description = "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.",
                        SectionOrder = 3,
                    },
                    new ()
                    {
                        Id = 4,
                        Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                        Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                        SectionOrder = 4,
                    },
                    new ()
                    {
                        Id = 5,
                        Title = "СЪСТАВ, INCI",
                        Description = "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio",
                        SectionOrder = 5,
                    }
                ],
                Images = [],
                ProductsCategories =
                [
                    new ()
                    {
                        Id = 1,
                        Name = "всички",
                    },
                    new ()
                    {
                        Id = 2,
                        Name = "за тяло",
                    },
                    new ()
                    {
                        Id = 3,
                        Name = "за суха кожа",
                    }
                ],
            };

            var listProductsIds = _mockDbContext.Products.Select(p => p.Id).ToList();

            // Act
            var actual = await _adminDetailsService.CreateProductByTemplateAsync(1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.AvailableQuantity, actual.AvailableQuantity);
            Assert.AreEqual(expected.Optional, actual.Optional);
            Assert.AreEqual(expected.Sections.Count, actual.Sections.Count);
            for (int i = 0; i < expected.Sections.Count; i++)
            {
                Assert.AreEqual(expected.Sections[i].Title, actual.Sections[i].Title);
                Assert.AreEqual(expected.Sections[i].Description, actual.Sections[i].Description);
                Assert.AreEqual(expected.Sections[i].SectionOrder, actual.Sections[i].SectionOrder);
            };
            Assert.AreEqual(expected.Images.Count, actual.Images.Count);
            Assert.AreEqual(expected.ProductsCategories.Count, actual.ProductsCategories.Count);
            actual.ProductsCategories = actual.ProductsCategories.OrderBy(c => c.Id).ToList();
            expected.ProductsCategories = expected.ProductsCategories.OrderBy(c => c.Id).ToList();
            for (int i = 0; i < expected.ProductsCategories.Count; i++)
            {
                Assert.AreEqual(expected.ProductsCategories[i].Id, actual.ProductsCategories[i].Id);
                Assert.AreEqual(expected.ProductsCategories[i].Name, actual.ProductsCategories[i].Name);
            };
            Assert.IsFalse(listProductsIds.Contains(actual.Id));

            // Clean up
            _mockDbContext.Products.Remove(_mockDbContext.Products.Find(actual.Id));
        }

        [Test]
        public async Task CreateProductByTemplateAsync_ShouldCreateNewProductIfProductIdNotExist()
        {
            // Arrange
            AdminDetailsDTO expected = new()
            {
                Name = "Нов продукт",
                Price = 0,
                Quantity = 0,
                Optional = "",
                Sections = [],
                ProductsCategories = []
            };

            var listProductsIds = _mockDbContext.Products.Select(p => p.Id).ToList();

            // Act
            var actual = await _adminDetailsService.CreateProductByTemplateAsync(100);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.AvailableQuantity, actual.AvailableQuantity);
            Assert.AreEqual(expected.Optional, actual.Optional);
            Assert.AreEqual(expected.Sections.Count, actual.Sections.Count);
            Assert.AreEqual(expected.ProductsCategories.Count, actual.ProductsCategories.Count);
            Assert.IsFalse(listProductsIds.Contains(actual.Id));

            // Clean up
            _mockDbContext.Products.Remove(_mockDbContext.Products.Find(actual.Id));
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task EditNameAsync()
        {

            // Arrange
            string expected = "Променено име";

            // Act
            await _adminDetailsService.EditNameAsync(1, expected);
            var actual = _mockDbContext.Products.Find(1).Name;

            // Assert
            Assert.AreEqual(expected, actual);

            // Clean up
            _mockDbContext.Products.Find(1).Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ";
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task EditPriceAsync()
        {

            // Arrange
            decimal expected = 10.50m;

            // Act
            await _adminDetailsService.EditPriceAsync(1, expected);
            var actual = _mockDbContext.Products.Find(1).Price;

            // Assert
            Assert.AreEqual(expected, actual);

            // Clean up
            _mockDbContext.Products.Find(1).Price = 5.50m;
            _mockDbContext.SaveChanges();
        }


        [Test]
        public async Task AddProductImageAsync_ShouldAddImageToProductAtTheEndOfImageOrder()
        {
            // Arrange
            string imagePath = "/files/products/product-01-image-05.webp";
            int productId = 1;
            ImageProduct expected = new()
            {
                ProductId = productId,
                ImagePath = imagePath,
                ImageOrder = 5,
            };

            // Act
            await _adminDetailsService.AddProductImageAsync(productId, imagePath);
            var actual = _mockDbContext.ImageProducts.Where(i => i.ProductId == productId).OrderBy(i => i.ImageOrder).Last();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ProductId, actual.ProductId);
            Assert.AreEqual(expected.ImagePath, actual.ImagePath);
            Assert.AreEqual(expected.ImageOrder, actual.ImageOrder);

            // Clean up
            _mockDbContext.ImageProducts.Remove(actual);
            _mockDbContext.SaveChanges();

        }

        [Test]
        public async Task AddProductImageAsync_ShouldAddImageToProductAtTheEndOfImageOrder_WhenImagePathDoesNotExist()
        {
            // Arrange
            string? imagePath = null;
            int productId = 1;

            var expected = _mockDbContext.ImageProducts.Where(i => i.ProductId == productId).OrderBy(i => i.ImageOrder).Last();
            // Act
            await _adminDetailsService.AddProductImageAsync(productId, imagePath);
            var actual = _mockDbContext.ImageProducts.Where(i => i.ProductId == productId).OrderBy(i => i.ImageOrder).Last();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ProductId, actual.ProductId);
            Assert.AreEqual(expected.ImagePath, actual.ImagePath);
            Assert.AreEqual(expected.ImageOrder, actual.ImageOrder);
        }

        [Test]
        public async Task RemoveImageAsync_ShouldRemoveImageFromProductAndReorderImages()
        {
            // Arrange
            ImageProduct imageToRemove = _mockDbContext.ImageProducts.Find(3);
            int[] expectedImagesId = { 1, 2, 4 };
            int[] expectedImagesOrders = { 1, 2, 3 };

            // Act
            await _adminDetailsService.RemoveImageAsync(1, 3);
            var actual = _mockDbContext.ImageProducts.Where(ip => ip.ProductId == 1);
            var actualImagesId = actual.Select(i => i.Id).ToArray();
            var actualImagesOrders = actual.Select(i => i.ImageOrder).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedImagesId.Length, actualImagesId.Length);
            for (int i = 0; i < expectedImagesId.Length; i++)
            {
                Assert.AreEqual(expectedImagesId[i], actualImagesId[i]);
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }
            Assert.AreEqual(expectedImagesOrders.Length, actualImagesOrders.Length);
            for (int i = 0; i < expectedImagesOrders.Length; i++)
            {
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }

            // Clean up
            ResetImageProducts();
        }

        [Test]
        public async Task MoveImageLeftAsync_ShouldMoveImageToTheLeftAndReorderImages()
        {
            // Arrange
            int imageId = 3;
            int[] expectedImagesId = { 1, 2, 3, 4 };
            int[] expectedImagesOrders = { 1, 3, 2, 4 };

            // Act
            await _adminDetailsService.MoveImageLeftAsync(1, imageId);
            var actual = _mockDbContext.ImageProducts.Where(ip => ip.ProductId == 1);
            var actualImagesId = actual.Select(i => i.Id).ToArray();
            var actualImagesOrders = actual.Select(i => i.ImageOrder).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedImagesId.Length, actualImagesId.Length);
            for (int i = 0; i < expectedImagesId.Length; i++)
            {
                Assert.AreEqual(expectedImagesId[i], actualImagesId[i]);
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }
            Assert.AreEqual(expectedImagesOrders.Length, actualImagesOrders.Length);
            for (int i = 0; i < expectedImagesOrders.Length; i++)
            {
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }

            // Clean up
            ResetImageProducts();
        }

        [Test]
        public async Task MoveImageLeftAsync_ShouldNotMoveImageToTheLeftAndNotReorderImages()
        {
            // Arrange
            int imageId = 1;
            int[] expectedImagesId = { 1, 2, 3, 4 };
            int[] expectedImagesOrders = { 1, 2, 3, 4 };

            // Act
            await _adminDetailsService.MoveImageLeftAsync(1, imageId);
            var actual = _mockDbContext.ImageProducts.Where(ip => ip.ProductId == 1);
            var actualImagesId = actual.Select(i => i.Id).ToArray();
            var actualImagesOrders = actual.Select(i => i.ImageOrder).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedImagesId.Length, actualImagesId.Length);
            for (int i = 0; i < expectedImagesId.Length; i++)
            {
                Assert.AreEqual(expectedImagesId[i], actualImagesId[i]);
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }
            Assert.AreEqual(expectedImagesOrders.Length, actualImagesOrders.Length);
            for (int i = 0; i < expectedImagesOrders.Length; i++)
            {
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }

            // Clean up
            ResetImageProducts();
        }

        [Test]
        public async Task MoveImageRightAsync_ShouldMoveImageToTheLeftAndReorderImages()
        {
            // Arrange
            int imageId = 3;
            int[] expectedImagesId = { 1, 2, 3, 4 };
            int[] expectedImagesOrders = { 1, 2, 4, 3 };

            // Act
            await _adminDetailsService.MoveImageRightAsync(1, imageId);
            var actual = _mockDbContext.ImageProducts.Where(ip => ip.ProductId == 1);
            var actualImagesId = actual.Select(i => i.Id).ToArray();
            var actualImagesOrders = actual.Select(i => i.ImageOrder).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedImagesId.Length, actualImagesId.Length);
            for (int i = 0; i < expectedImagesId.Length; i++)
            {
                Assert.AreEqual(expectedImagesId[i], actualImagesId[i]);
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }
            Assert.AreEqual(expectedImagesOrders.Length, actualImagesOrders.Length);
            for (int i = 0; i < expectedImagesOrders.Length; i++)
            {
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }

            // Clean up
            ResetImageProducts();
        }

        [Test]
        public async Task MoveImageRightAsync_ShouldNotMoveImageToTheLeftAndNotReorderImages()
        {
            // Arrange
            int imageId = 4;
            int[] expectedImagesId = { 1, 2, 3, 4 };
            int[] expectedImagesOrders = { 1, 2, 3, 4 };

            // Act
            await _adminDetailsService.MoveImageRightAsync(1, imageId);
            var actual = _mockDbContext.ImageProducts.Where(ip => ip.ProductId == 1);
            var actualImagesId = actual.Select(i => i.Id).ToArray();
            var actualImagesOrders = actual.Select(i => i.ImageOrder).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedImagesId.Length, actualImagesId.Length);
            for (int i = 0; i < expectedImagesId.Length; i++)
            {
                Assert.AreEqual(expectedImagesId[i], actualImagesId[i]);
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }
            Assert.AreEqual(expectedImagesOrders.Length, actualImagesOrders.Length);
            for (int i = 0; i < expectedImagesOrders.Length; i++)
            {
                Assert.AreEqual(expectedImagesOrders[i], actualImagesOrders[i]);
            }

            // Clean up
            ResetImageProducts();
        }

        [Test]
        public async Task AddSectionAsync()
        {
            // Arrange
            Section expected = new Section
            {
                Title = "",
                Description = "",
                SectionOrder = 6,
                ProductId = 1
            };

            // Act
            await _adminDetailsService.AddSectionAsync(1);

            // Assert
            var actual = _mockDbContext.Sections.Where(s => s.ProductId == 1).OrderBy(s => s.SectionOrder).Last();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.SectionOrder, actual.SectionOrder);
            Assert.AreEqual(expected.ProductId, actual.ProductId);

            // Clean up
            _mockDbContext.Sections.Remove(actual);
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task EditSectionAsync()
        {
            // Arrange
            var section = _mockDbContext.Sections.Find(1);
            string oldTitle = section.Title;
            string oldDescription = section.Description;

            string newTitle = "Променен раздел";
            string newDescription = "Променено описание";
            Section expected = new Section
            {
                Id = 1,
                Title = newTitle,
                Description = newDescription,
                SectionOrder = 1,
                ProductId = 1
            };

            // Act
            await _adminDetailsService.EditSectionAsync(1, newTitle, newDescription);
            var actual = _mockDbContext.Sections.Find(1);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Title, actual.Title);
            Assert.AreEqual(expected.Description, actual.Description);

            // Clean up
            _mockDbContext.Sections.Find(1).Title = oldTitle;
            _mockDbContext.Sections.Find(1).Description = oldDescription;
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task DeleteSectionAsync_ShouldDeleteSectionAndReorderSections()
        {
            // Arrange
            int sectionId = 2;
            var sectionToBeDeleted = _mockDbContext.Sections.Find(sectionId);
            int[] expectedSectionsId = { 1, 3, 4, 5 };
            int[] expectedSectionsOrders = { 1, 2, 3, 4 };

            // Act
            await _adminDetailsService.DeleteSectionAsync(1, sectionId);
            var actual = _mockDbContext.Sections.Where(s => s.ProductId == 1);
            var actualSectionsId = actual.Select(s => s.Id).ToArray();
            var actualSectionsOrders = actual.Select(s => s.SectionOrder).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedSectionsId.Length, actualSectionsId.Length);
            for (int i = 0; i < expectedSectionsId.Length; i++)
            {
                Assert.AreEqual(expectedSectionsId[i], actualSectionsId[i]);
                Assert.AreEqual(expectedSectionsOrders[i], actualSectionsOrders[i]);
            }
            Assert.AreEqual(expectedSectionsOrders.Length, actualSectionsOrders.Length);
            for (int i = 0; i < expectedSectionsOrders.Length; i++)
            {
                Assert.AreEqual(expectedSectionsOrders[i], actualSectionsOrders[i]);
            }

            // Clean up
            ResetSections();
        }

        [Test]
        public async Task MoveSectionDownAsync()
        {
            // Arrange
            int sectionId = 2;
            int[] expectedSectionsId = { 1, 2, 3, 4, 5 };
            int[] expectedSectionsOrders = { 1, 3, 2, 4, 5 };

            // Act
            await _adminDetailsService.MoveSectionDownAsync(1, sectionId);
            var actual = _mockDbContext.Sections.Where(s => s.ProductId == 1).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedSectionsId.Length, actual.Length);
            for (int i = 0; i < expectedSectionsId.Length; i++)
            {
                Assert.AreEqual(expectedSectionsId[i], actual[i].Id);
                Assert.AreEqual(expectedSectionsOrders[i], actual[i].SectionOrder);
            }

            // Clean up
            ResetSections();
        }

        [Test]
        public async Task MoveSectionDownAsync_ShouldNotWorkWhenSectionOrderNumberIsLast()
        {
            // Arrange
            int sectionId = 5;
            int[] expectedSectionsId = { 1, 2, 3, 4, 5 };
            int[] expectedSectionsOrders = { 1, 2, 3, 4, 5 };

            // Act
            await _adminDetailsService.MoveSectionDownAsync(1, sectionId);
            var actual = _mockDbContext.Sections.Where(s => s.ProductId == 1).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedSectionsId.Length, actual.Length);
            for (int i = 0; i < expectedSectionsId.Length; i++)
            {
                Assert.AreEqual(expectedSectionsId[i], actual[i].Id);
                Assert.AreEqual(expectedSectionsOrders[i], actual[i].SectionOrder);
            }

            // Clean up
            ResetSections();
        }

        [Test]
        public async Task MoveSectionUpAsync()
        {
            // Arrange
            int sectionId = 5;
            int[] expectedSectionsId = { 1, 2, 3, 4, 5 };
            int[] expectedSectionsOrders = { 1, 2, 3, 5, 4 };

            // Act
            await _adminDetailsService.MoveSectionUpAsync(1, sectionId);
            var actual = _mockDbContext.Sections.Where(s => s.ProductId == 1).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedSectionsId.Length, actual.Length);
            for (int i = 0; i < expectedSectionsId.Length; i++)
            {
                Assert.AreEqual(expectedSectionsId[i], actual[i].Id);
                Assert.AreEqual(expectedSectionsOrders[i], actual[i].SectionOrder);
            }

            // Clean up
            ResetSections();
        }

        [Test]
        public async Task MoveSectionUpAsync_ShouldNotWorkWhenSectionOrderNumberIsOne()
        {
            // Arrange
            int sectionId = 1;
            int[] expectedSectionsId = { 1, 2, 3, 4, 5 };
            int[] expectedSectionsOrders = { 1, 2, 3, 4, 5 };

            // Act
            await _adminDetailsService.MoveSectionUpAsync(1, sectionId);
            var actual = _mockDbContext.Sections.Where(s => s.ProductId == 1).ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedSectionsId.Length, actual.Length);
            for (int i = 0; i < expectedSectionsId.Length; i++)
            {
                Assert.AreEqual(expectedSectionsId[i], actual[i].Id);
                Assert.AreEqual(expectedSectionsOrders[i], actual[i].SectionOrder);
            }

            // Clean up
            ResetSections();
        }

        [Test]
        public async Task AddRemoveCategoryAsync_ShouldAddCategoryToProduct()
        {
            // Arrange
            int productId = 1;
            int categoryId = 4;
            var expected = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };

            // Act
            await _adminDetailsService.AddRemoveCategoryAsync(productId, categoryId);
            var actual = _mockDbContext.ProductsCategories.Find(productId, categoryId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.ProductId, actual.ProductId);
            Assert.AreEqual(expected.CategoryId, actual.CategoryId);

            // Clean up
            _mockDbContext.ProductsCategories.Remove(actual);
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task AddRemoveCategoryAsync_ShouldRemoveCategoryFromProduct()
        {
            // Arrange
            int productId = 1;
            int categoryId = 2;
            var expected = _mockDbContext.ProductsCategories.Find(productId, categoryId);

            // Act
            await _adminDetailsService.AddRemoveCategoryAsync(productId, categoryId);
            var actual = _mockDbContext.ProductsCategories.Find(productId, categoryId);

            // Assert
            Assert.IsNull(actual);

            // Clean up
            _mockDbContext.ProductsCategories.Add(expected);
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task AddQuantityAsync_ShouldAddQuantityToProduct()
        {
            // Arrange
            int productId = 1;
            int quantity = 10;
            int expected = _mockDbContext.Products.Find(productId).Quantity + quantity;

            // Act
            await _adminDetailsService.AddQuantityAsync(productId, quantity);
            var actual = _mockDbContext.Products.Find(productId).Quantity;

            // Assert
            Assert.AreEqual(expected, actual);

            // Clean up
            _mockDbContext.Products.Find(productId).Quantity -= quantity;
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task EditOptionalAsync()
        {
            // Arrange
            string oldOptional = _mockDbContext.Products.Find(1).Optional;
            string expected = "new optional";

            // Act
            await _adminDetailsService.EditOptionalAsync(1, expected);
            var actual = _mockDbContext.Products.Find(1).Optional;

            // Assert
            Assert.AreEqual(expected, actual);

            // Clean up
            _mockDbContext.Products.Find(1).Optional = oldOptional;
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task AddNewCategoryAsync()
        {
            // Arrange
            Category expected = new Category
            {
                Name = "Нова категория"
            };

            // Act
            await _adminDetailsService.AddNewCategoryAsync(expected.Name);
            var actual = _mockDbContext.Categories.Where(c => c.Name == expected.Name).FirstOrDefault();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Name, actual.Name);

            // Clean up
            _mockDbContext.Categories.Remove(actual);
            _mockDbContext.SaveChanges();
        }

        [Test]
        public async Task DeleteCategoryAsync_ShouldDeleteCategoryWithoutProducts()
        {
            // Arrange
            await _adminDetailsService.AddNewCategoryAsync("new category");
            int categoryId = _mockDbContext.Categories.Where(c => c.Name == "new category").FirstOrDefault().Id;
            Assert.IsNotNull(_mockDbContext.Categories.Find(categoryId));

            // Act
            await _adminDetailsService.DeleteCategoryAsync(categoryId);
            var actual = _mockDbContext.Categories.Find(categoryId);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public async Task DeleteCategoryAsync_ShouldNotDeleteCategoryWithProducts()
        {
            // Arrange
            int categoryId = 1;
            Assert.IsNotNull(_mockDbContext.Categories.Find(categoryId));

            // Act
            await _adminDetailsService.DeleteCategoryAsync(categoryId);
            var actual = _mockDbContext.Categories.Find(categoryId);

            // Assert
            Assert.IsNotNull(actual);
        }
    }
}
