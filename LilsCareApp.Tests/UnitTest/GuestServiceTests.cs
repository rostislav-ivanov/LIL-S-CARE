using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.GuestUser;
using LilsCareApp.Core.Services;
using Moq;

namespace LilsCareApp.Tests.UnitTest
{
    public class GuestServiceTests : UnitTestsBase
    {
        private IGuestService _guestService;

        private string userId;

        [OneTimeSetUp]
        public void SetUp()
        {
            var sessionManagerMock = new Mock<IGuestSessionManager>();
            sessionManagerMock.Setup(m => m.GetSession()).Returns(new GuestSession());
            sessionManagerMock.Setup(m => m.SetSession(It.IsAny<GuestSession>()));
            _guestService = new GuestService(sessionManagerMock.Object, _mockDbContext);
        }

        [Test]
        public void AddToCart_ShouldAddProductToCartToEmptyCard()
        {
            // Arrange
            var productId = 1;
            var quantity = 1;

            // Act
            _guestService.AddToCart(productId, quantity);

            // Assert
            var session = _guestService.GetSession();
            Assert.NotNull(session);
            Assert.AreEqual(1, session.GuestBags.Count);
            Assert.AreEqual(productId, session.GuestBags[0].ProductId);
            Assert.AreEqual(quantity, session.GuestBags[0].Quantity);
        }

        //[Test]
        //public void AddToCart_ShouldAddProductToCartToNonEmptyCard()
        //{
        //    // Arrange
        //    var productId = 1;
        //    var quantity = 1;

        //    // Act
        //    _guestService.AddToCart(productId, quantity);
        //    _guestService.AddToCart(productId, quantity);

        //    // Assert
        //    var session = _guestService.GetSession();
        //    Assert.NotNull(session);
        //    Assert.AreEqual(1, session.GuestBags.Count);
        //    Assert.AreEqual(productId, session.GuestBags[0].ProductId);
        //    Assert.AreEqual(2, session.GuestBags[0].Quantity);
        //}

    }
}
