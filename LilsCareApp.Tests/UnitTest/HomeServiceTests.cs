using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Home;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Tests.UnitTest
{
    public class HomeServiceTests : UnitTestsBase
    {
        private IHomeService _homeService;

        private string userId;

        [OneTimeSetUp]
        public void SetUp()
        {
            _homeService = new HomeService(_mockDbContext);
            userId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef";
        }

        [Test]
        public async Task AddToSubscribersAsync_ShouldAddSubscriber()
        {
            // Arrange
            var subscriber = new SubscriberDTO
            {
                EmailSubscriber = "subscriber@mail.com",
                PrivacyPolicyCheckBox = true,
                AppUserId = userId
            };

            Subscriber expected = new()
            {
                Email = subscriber.EmailSubscriber,
                AppUserId = userId
            };

            // Act
            await _homeService.AddToSubscribersAsync(subscriber);

            // Assert
            var actual = _mockDbContext.Subscribers.FirstOrDefault(s => s.AppUserId == userId && s.Email == subscriber.EmailSubscriber);

            Assert.NotNull(actual);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.AppUserId, actual.AppUserId);
        }

        [Test]
        public async Task MessageFromClientAsync_ShouldAddMessageFromClient()
        {
            // Arrange
            var message = new ContactUsDTO
            {
                FirstName = "John",
                LastName = "Doe",
                EmailForResponse = "JohnDou@mail.com",
                Message = "Hello, I have a question.",
                PrivacyPolicy = true,
                AppUserId = userId
            };

            MessageFromClient expected = new()
            {
                EmailForResponse = message.EmailForResponse,
                FirstName = message.FirstName,
                LastName = message.LastName,
                Message = message.Message,
                AppUserId = userId
            };

            // Act
            await _homeService.MessageFromClientAsync(message);

            // Assert
            var actual = _mockDbContext.MessagesFromClients.FirstOrDefault(m => m.AppUserId == userId && m.EmailForResponse == message.EmailForResponse);

            Assert.NotNull(actual);
            Assert.AreEqual(expected.EmailForResponse, actual.EmailForResponse);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.AppUserId, actual.AppUserId);
        }
    }
}
