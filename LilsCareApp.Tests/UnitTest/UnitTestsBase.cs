using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Tests.SeedDb;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Tests.UnitTest
{
    public class UnitTestsBase
    {
        protected ApplicationDbContext _mockDbContext;

        protected SeedData SeedData = new SeedData();

        [OneTimeSetUp]
        public void SetUpBase()
        {
            var mockDbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ApplicationDbContext" + DateTime.Now.Ticks.ToString())
                .Options;

            _mockDbContext = new ApplicationDbContext(mockDbOptions);


            _mockDbContext.Users.AddRange(SeedData.Users);
            _mockDbContext.Roles.AddRange(SeedData.Roles);
            _mockDbContext.UserRoles.Add(SeedData.UserRole);
            _mockDbContext.Products.AddRange(SeedData.Products);
            _mockDbContext.Categories.AddRange(SeedData.Categories);
            _mockDbContext.ProductsCategories.AddRange(SeedData.ProductsCategories);
            _mockDbContext.ImageProducts.AddRange(SeedData.Images);
            _mockDbContext.Reviews.AddRange(SeedData.Reviews);
            _mockDbContext.ProductsOrders.AddRange(SeedData.ProductsOrders);
            _mockDbContext.Orders.AddRange(SeedData.Orders);
            _mockDbContext.StatusOrders.AddRange(SeedData.StatusOrders);
            _mockDbContext.ShippingProviders.AddRange(SeedData.ShippingProviders);
            _mockDbContext.PaymentMethods.AddRange(SeedData.PaymentMethods);
            _mockDbContext.AddressDeliveries.AddRange(SeedData.AddressDeliveries);
            _mockDbContext.WishesUsers.AddRange(SeedData.WishesUsers);
            _mockDbContext.BagsUsers.AddRange(SeedData.BagsUsers);
            _mockDbContext.ShippingOffices.AddRange(SeedData.ShippingOffice);
            _mockDbContext.PromoCodes.AddRange(SeedData.PromoCodes);
            _mockDbContext.Sections.AddRange(SeedData.Sections);
            _mockDbContext.Reviews.AddRange(SeedData.Reviews);


            _mockDbContext.SaveChanges();
        }

        public void ResetBagsUsers()
        {
            var newSeedData = new SeedData();
            _mockDbContext.BagsUsers.RemoveRange(_mockDbContext.BagsUsers.ToList());
            _mockDbContext.BagsUsers.AddRange(newSeedData.BagsUsers);
            _mockDbContext.SaveChanges();
        }

        public void ResetWishesUsers()
        {
            var newSeedData = new SeedData();
            _mockDbContext.WishesUsers.RemoveRange(_mockDbContext.WishesUsers.ToList());
            _mockDbContext.WishesUsers.AddRange(newSeedData.WishesUsers);
            _mockDbContext.SaveChanges();
        }

        public void ResetReviews()
        {
            var newSeedData = new SeedData();
            _mockDbContext.Reviews.RemoveRange(_mockDbContext.Reviews.ToList());
            _mockDbContext.Reviews.AddRange(newSeedData.Reviews);
            _mockDbContext.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            _mockDbContext.Dispose();
        }
    }
}
