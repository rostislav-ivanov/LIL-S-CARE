using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Details;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data.Models;
using System.Globalization;

namespace LilsCareApp.Tests.UnitTest
{
    [TestFixture]
    public class DetailsServiceTests : UnitTestsBase
    {
        private IDetailsService _detailsService;

        private string userId;


        [OneTimeSetUp]
        public void SetUp()
        {
            _detailsService = new DetailsService(_mockDbContext);
            userId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef";
        }

        [Test]
        public async Task GetDetailsByIdAsync_ShouldWorkCorrectly()
        {
            // Arrange
            DetailsDTO expected = new()
            {
                Id = 2,
                Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                Price = 4.00m,
                Optional = "Тегло:  5 г.",
                Quantity = 1,
                AvailableQuantity = 20,
                Sections =
                [
                    new ()
                    {
                        Id = 6,
                        Title = "ОПИСАНИЕ",
                        Description = "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n \r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\nВ два варианта:\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\nОбогатен с витамин Е и био масло от жожоба.\r\n \r\n100% натурален\r\n49% от България\r\n41% био",
                        SectionOrder = 1,
                    },
                    new ()
                    {
                        Id = 7,
                        Title = "ЗА СЪСТАВКИТЕ",
                        Description = "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n \r\nМаслото от жожоба* ги подхранва.\r\n \r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n \r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n \r\n*Био 41% от състава",
                        SectionOrder = 2
                    },
                    new ()
                    {
                        Id = 8,
                        Title = "УПОТРЕБА",
                        Description = "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.",
                        SectionOrder = 3
                    },
                    new ()
                    {
                        Id = 9,
                        Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                        Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                        SectionOrder = 4
                    },
                    new ()
                    {
                        Id = 10,
                        Title = "СЪСТАВ, INCI",
                        Description = "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%",
                        SectionOrder = 5
                    }
                ],
                Images =
                [
                    new ()
                    {
                        ImagePath = "/files/products/product-02-image-01.webp",
                        IsVideo = false,
                    },
                    new ()
                    {
                        ImagePath = "/files/products/product-02-image-02.webp",
                        IsVideo = false,
                    },
                    new ()
                    {
                        ImagePath = "/files/products/product-02-image-03.webp",
                        IsVideo = false,
                    },
                    new ()
                    {
                        ImagePath = "/files/products/product-02-image-04.webp",
                        IsVideo = false,
                    },
                    new ()
                    {
                        ImagePath = "/files/products/product-02-image-05.webp",
                        IsVideo = false,
                    },
                ],
                Reviews =
                [
                    new ()
                    {
                        ProductId = 2,
                        AuthorName = "test@softuni.bg",
                        AuthorEmail = "test@softuni.bg",
                        AuthorImage = "/files/users/test-testov.jpg",
                        Rating = 4,
                        Title = "Great product",
                        Comment = "Great product, I love it!",
                        Images = [],
                        CreatedOn = DateTime.ParseExact("28/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    }
                ],
                Rating = 4,
                ProductsCategories =
                [
                    new () { Id = 1, Name = "всички" },
                    new () { Id = 3, Name = "за суха кожа" },
                    new () { Id = 4, Name = "за мазна кожа" },
                ],
                IsWish = true,
            };

            // Act
            var result = await _detailsService.GetDetailsByIdAsync(2, userId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Price, result.Price);
            Assert.AreEqual(expected.Optional, result.Optional);
            Assert.AreEqual(expected.Quantity, result.Quantity);
            Assert.AreEqual(expected.AvailableQuantity, result.AvailableQuantity);
            Assert.AreEqual(expected.Sections.Count, result.Sections.Count);
            for (int i = 0; i < result.Sections.Count; i++)
            {
                Assert.AreEqual(expected.Sections[i].Id, result.Sections[i].Id);
                Assert.AreEqual(expected.Sections[i].Title, result.Sections[i].Title);
                Assert.AreEqual(expected.Sections[i].Description, result.Sections[i].Description);
                Assert.AreEqual(expected.Sections[i].SectionOrder, result.Sections[i].SectionOrder);
            }
            Assert.AreEqual(expected.Images.Count, result.Images.Count);
            for (int i = 0; i < result.Images.Count; i++)
            {
                Assert.AreEqual(expected.Images[i].ImagePath, result.Images[i].ImagePath);
                Assert.AreEqual(expected.Images[i].IsVideo, result.Images[i].IsVideo);
                var imageOrder = _mockDbContext.ImageProducts
                    .Where(im => im.ImagePath == expected.Images[i].ImagePath)
                    .Select(im => im.ImageOrder).FirstOrDefault();
                Assert.AreEqual(imageOrder, i + 1);
            }
            Assert.AreEqual(expected.Reviews.Count, result.Reviews.Count);
            for (int i = 0; i < result.Reviews.Count; i++)
            {
                Assert.AreEqual(expected.Reviews[i].ProductId, result.Reviews[i].ProductId);
                Assert.AreEqual(expected.Reviews[i].AuthorName, result.Reviews[i].AuthorName);
                Assert.AreEqual(expected.Reviews[i].AuthorEmail, result.Reviews[i].AuthorEmail);
                Assert.AreEqual(expected.Reviews[i].AuthorImage, result.Reviews[i].AuthorImage);
                Assert.AreEqual(expected.Reviews[i].Rating, result.Reviews[i].Rating);
                Assert.AreEqual(expected.Reviews[i].Title, result.Reviews[i].Title);
                Assert.AreEqual(expected.Reviews[i].Comment, result.Reviews[i].Comment);
                Assert.AreEqual(expected.Reviews[i].Images, result.Reviews[i].Images);
                Assert.AreEqual(expected.Reviews[i].CreatedOn, result.Reviews[i].CreatedOn);
            }
            Assert.AreEqual(expected.Rating, result.Rating);
            Assert.AreEqual(expected.ProductsCategories.Count, result.ProductsCategories.Count);
            for (int i = 0; i < result.ProductsCategories.Count; i++)
            {
                Assert.AreEqual(expected.ProductsCategories[i].Id, result.ProductsCategories[i].Id);
                Assert.AreEqual(expected.ProductsCategories[i].Name, result.ProductsCategories[i].Name);
            }
            Assert.AreEqual(expected.IsWish, result.IsWish);
        }

        [Test]
        public async Task GetDetailsByIdAsync_WithInvalidProductId_ShouldReturnNull()
        {
            // Act
            var result = await _detailsService.GetDetailsByIdAsync(100, userId);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task GetDetailsByIdAsync_WithInvalidUserId_ShouldReturnNull()
        {
            // Act
            var result = await _detailsService.GetDetailsByIdAsync(2, "invalidUserId");

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task GetReviewAsync_ShouldWorkCorrectly()
        {
            // Arrange
            AddReviewDTO expected = new()
            {
                ProductId = 2,
                ProductName = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                ProductImage = "/files/products/product-02-image-01.webp",
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                AuthorName = "test@softuni.bg",
                Email = "test@softuni.bg",
                Title = "Great product",
                Comment = "Great product, I love it!",
                Images = [],
                Stars = [true, true, true, true, false],
                Rating = 4,
            };

            // Act
            var result = await _detailsService.GetReviewAsync(2, userId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expected.ProductId, result.ProductId);
            Assert.AreEqual(expected.ProductName, result.ProductName);
            Assert.AreEqual(expected.ProductImage, result.ProductImage);
            Assert.AreEqual(expected.AuthorId, result.AuthorId);
            Assert.AreEqual(expected.AuthorName, result.AuthorName);
            Assert.AreEqual(expected.Email, result.Email);
            Assert.AreEqual(expected.Title, result.Title);
            Assert.AreEqual(expected.Comment, result.Comment);
            Assert.AreEqual(expected.Images, result.Images);
            Assert.AreEqual(expected.Stars, result.Stars);
        }

        [Test]
        public async Task GetReviewAsync_WithInvalidProductId_ShouldReturnNull()
        {
            // Act
            var result = await _detailsService.GetReviewAsync(100, userId);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task GetReviewAsync_WithInvalidUserId_ShouldReturnNull()
        {
            // Act
            var result = await _detailsService.GetReviewAsync(2, "invalidUserId");

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task SaveReviewAsync_ShouldReplaseOldReview()
        {
            // Arrange
            AddReviewDTO newReview = new()
            {
                ProductId = 2,
                ProductName = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                ProductImage = "/files/products/product-02-image-01.webp",
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                AuthorName = "test@softuni.bg",
                Email = "test@softuni.bg",
                Title = "New Great product",
                Comment = "New Great product, I love it!",
                Images =
                [
                    new () { ImagePath = "/files/reviews/product-02-image-01.jpeg"},
                    new () { ImagePath = "/files/reviews/product-02-image-02.jpeg"},
                ],
                Stars = [true, true, true, true, true],
                Rating = 5,
            };

            Review expected = new()
            {
                ProductId = 2,
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                Rating = 5,
                Title = "New Great product",
                Comment = "New Great product, I love it!",
                Images =
                [
                    new ()
                    {
                        ProductId = 2,
                        AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                        ImagePath = "/files/reviews/product-02-image-01.jpeg"
                    },
                    new ()
                    {
                        ProductId = 2,
                        AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                        ImagePath = "/files/reviews/product-02-image-02.jpeg"
                    }
                ],
            };


            // Act
            var oldReview = _mockDbContext.Reviews.Find(2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef");
            await _detailsService.SaveReviewAsync(newReview);

            // Assert
            var result = _mockDbContext.Reviews.Find(2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef");
            Assert.NotNull(oldReview);
            Assert.NotNull(result);
            Assert.AreEqual(expected.ProductId, result.ProductId);
            Assert.AreEqual(expected.AuthorId, result.AuthorId);
            Assert.AreEqual(expected.Rating, result.Rating);
            Assert.AreEqual(expected.Title, result.Title);
            Assert.AreEqual(expected.Comment, result.Comment);
            Assert.AreEqual(expected.Images.Count, result.Images.Count);
            for (int i = 0; i < result.Images.Count; i++)
            {
                Assert.AreEqual(expected.Images[i].ProductId, result.Images[i].ProductId);
                Assert.AreEqual(expected.Images[i].AuthorId, result.Images[i].AuthorId);
                Assert.AreEqual(expected.Images[i].ImagePath, result.Images[i].ImagePath);
            }

            ResetReviews();
        }

        [Test]
        public async Task SaveReviewAsync_ShouldAddNewReview()
        {
            // Arrange
            AddReviewDTO newReview = new()
            {
                ProductId = 3,
                ProductName = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                ProductImage = "/files/products/product-03-image-01.webp",
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                AuthorName = "test@softuni.bg",
                Email = "test@softuni.bg",
                Title = "New Great product 3",
                Comment = "New Great product 3, I love it!",
                Images =
                [
                    new () { ImagePath = "/files/reviews/product-03-image-01.jpeg"},
                    new () { ImagePath = "/files/reviews/product-03-image-02.jpeg"},
                ],
                Stars = [true, true, true, true, false],
                Rating = 4,
            };

            Review expected = new()
            {
                ProductId = 3,
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                Rating = 4,
                Title = "New Great product 3",
                Comment = "New Great product 3, I love it!",
                Images =
                [
                    new ()
                    {
                        ProductId = 3,
                        AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                        ImagePath = "/files/reviews/product-03-image-01.jpeg"
                    },
                    new ()
                    {
                        ProductId = 3,
                        AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                        ImagePath = "/files/reviews/product-03-image-02.jpeg"
                    }
                 ],
            };

            // Act
            var nonReview = _mockDbContext.Reviews.Find(3, "85fbe739-6be0-429d-b44b-1ce6cf7eeef");
            await _detailsService.SaveReviewAsync(newReview);

            // Assert
            Assert.Null(nonReview);
            var result = _mockDbContext.Reviews.Find(3, "85fbe739-6be0-429d-b44b-1ce6cf7eeef");
            Assert.NotNull(result);
            Assert.AreEqual(expected.ProductId, result.ProductId);
            Assert.AreEqual(expected.AuthorId, result.AuthorId);
            Assert.AreEqual(expected.Rating, result.Rating);
            Assert.AreEqual(expected.Title, result.Title);
            Assert.AreEqual(expected.Comment, result.Comment);
            Assert.AreEqual(expected.Images.Count, result.Images.Count);
            for (int i = 0; i < result.Images.Count; i++)
            {
                Assert.AreEqual(expected.Images[i].ProductId, result.Images[i].ProductId);
                Assert.AreEqual(expected.Images[i].AuthorId, result.Images[i].AuthorId);
                Assert.AreEqual(expected.Images[i].ImagePath, result.Images[i].ImagePath);
            }

            ResetReviews();
        }
    }
}

