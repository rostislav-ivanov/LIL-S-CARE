﻿//using LilsCareApp.Infrastructure.Data;
//using LilsCareApp.Tests.SeedDb;
//using Microsoft.EntityFrameworkCore;

//namespace LilsCareApp.Tests.UnitTest
//{
//    public class UnitTestsBase
//    {
//        protected ApplicationDbContext _mockDbContext;

//        protected SeedData SeedData = new SeedData();

//        [OneTimeSetUp]
//        public void SetUpBase()
//        {
//            var mockDbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//                .UseInMemoryDatabase("ApplicationDbContext" + DateTime.Now.Ticks.ToString())
//                .Options;

//            _mockDbContext = new ApplicationDbContext(mockDbOptions);


//            _mockDbContext.Users.AddRange(SeedData.Users);
//            _mockDbContext.Roles.AddRange(SeedData.Roles);
//            _mockDbContext.UserRoles.Add(SeedData.UserRole);
//            _mockDbContext.Products.AddRange(SeedData.Products);
//            _mockDbContext.Categories.AddRange(SeedData.Categories);
//            _mockDbContext.ProductsCategories.AddRange(SeedData.ProductsCategories);
//            _mockDbContext.ImageProducts.AddRange(SeedData.Images);
//            _mockDbContext.Reviews.AddRange(SeedData.Reviews);
//            _mockDbContext.ProductsOrders.AddRange(SeedData.ProductsOrders);
//            _mockDbContext.Orders.AddRange(SeedData.Orders);
//            _mockDbContext.StatusOrders.AddRange(SeedData.StatusOrders);
//            _mockDbContext.ShippingProviders.AddRange(SeedData.ShippingProviders);
//            _mockDbContext.PaymentMethods.AddRange(SeedData.PaymentMethods);
//            _mockDbContext.AddressDeliveries.AddRange(SeedData.AddressDeliveries);
//            _mockDbContext.WishesUsers.AddRange(SeedData.WishesUsers);
//            _mockDbContext.BagsUsers.AddRange(SeedData.BagsUsers);
//            _mockDbContext.ShippingOffices.AddRange(SeedData.ShippingOffice);
//            _mockDbContext.PromoCodes.AddRange(SeedData.PromoCodes);
//            _mockDbContext.Sections.AddRange(SeedData.Sections);
//            _mockDbContext.Reviews.AddRange(SeedData.Reviews);


//            _mockDbContext.SaveChanges();
//        }

//        public void ResetMockDbContext()
//        {
//            _mockDbContext.Users.RemoveRange(_mockDbContext.Users.ToList());
//            _mockDbContext.Products.RemoveRange(_mockDbContext.Products.ToList());
//            _mockDbContext.Categories.RemoveRange(_mockDbContext.Categories.ToList());
//            _mockDbContext.ProductsCategories.RemoveRange(_mockDbContext.ProductsCategories.ToList());
//            _mockDbContext.ImageProducts.RemoveRange(SeedData.Images.ToList());
//            _mockDbContext.Reviews.RemoveRange(_mockDbContext.Reviews.ToList());
//            _mockDbContext.ProductsOrders.RemoveRange(_mockDbContext.ProductsOrders.ToList());
//            _mockDbContext.Orders.RemoveRange(_mockDbContext.Orders.ToList());
//            _mockDbContext.StatusOrders.RemoveRange(_mockDbContext.StatusOrders.ToList());
//            _mockDbContext.ShippingProviders.RemoveRange(_mockDbContext.ShippingProviders.ToList());
//            _mockDbContext.PaymentMethods.RemoveRange(_mockDbContext.PaymentMethods.ToList());
//            _mockDbContext.AddressDeliveries.RemoveRange(_mockDbContext.AddressDeliveries.ToList());
//            _mockDbContext.WishesUsers.RemoveRange(_mockDbContext.WishesUsers.ToList());
//            _mockDbContext.BagsUsers.RemoveRange(_mockDbContext.BagsUsers.ToList());
//            _mockDbContext.ShippingOffices.RemoveRange(SeedData.ShippingOffice.ToList());
//            _mockDbContext.PromoCodes.RemoveRange(_mockDbContext.PromoCodes.ToList());
//            _mockDbContext.Sections.RemoveRange(_mockDbContext.Sections.ToList());
//            _mockDbContext.Reviews.RemoveRange(_mockDbContext.Reviews.ToList());

//            var newSeedData = new SeedData();

//            _mockDbContext.Users.AddRange(SeedData.Users);
//            _mockDbContext.UserRoles.Add(SeedData.UserRole);
//            _mockDbContext.Products.AddRange(SeedData.Products);
//            _mockDbContext.Categories.AddRange(SeedData.Categories);
//            _mockDbContext.ProductsCategories.AddRange(SeedData.ProductsCategories);
//            _mockDbContext.ImageProducts.AddRange(SeedData.Images);
//            _mockDbContext.Reviews.AddRange(SeedData.Reviews);
//            _mockDbContext.ProductsOrders.AddRange(SeedData.ProductsOrders);
//            _mockDbContext.Orders.AddRange(SeedData.Orders);
//            _mockDbContext.StatusOrders.AddRange(SeedData.StatusOrders);
//            _mockDbContext.ShippingProviders.AddRange(SeedData.ShippingProviders);
//            _mockDbContext.PaymentMethods.AddRange(SeedData.PaymentMethods);
//            _mockDbContext.AddressDeliveries.AddRange(SeedData.AddressDeliveries);
//            _mockDbContext.WishesUsers.AddRange(SeedData.WishesUsers);
//            _mockDbContext.BagsUsers.AddRange(SeedData.BagsUsers);
//            _mockDbContext.ShippingOffices.AddRange(SeedData.ShippingOffice);
//            _mockDbContext.PromoCodes.AddRange(SeedData.PromoCodes);
//            _mockDbContext.Sections.AddRange(SeedData.Sections);
//            _mockDbContext.Reviews.AddRange(SeedData.Reviews);


//            _mockDbContext.SaveChanges();
//        }

//        public void ResetBagsUsers()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.BagsUsers.RemoveRange(_mockDbContext.BagsUsers.ToList());
//            _mockDbContext.BagsUsers.AddRange(newSeedData.BagsUsers);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetWishesUsers()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.WishesUsers.RemoveRange(_mockDbContext.WishesUsers.ToList());
//            _mockDbContext.WishesUsers.AddRange(newSeedData.WishesUsers);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetReviews()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.Reviews.RemoveRange(_mockDbContext.Reviews.ToList());
//            _mockDbContext.Reviews.AddRange(newSeedData.Reviews);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetPromoCodes()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.PromoCodes.RemoveRange(_mockDbContext.PromoCodes.ToList());
//            _mockDbContext.PromoCodes.AddRange(newSeedData.PromoCodes);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetOrders()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.Orders.RemoveRange(_mockDbContext.Orders.ToList());
//            _mockDbContext.Orders.AddRange(newSeedData.Orders);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetUsers()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.Users.RemoveRange(_mockDbContext.Users.ToList());
//            _mockDbContext.Users.AddRange(newSeedData.Users);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetAddressDeliveries()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.AddressDeliveries.RemoveRange(_mockDbContext.AddressDeliveries.ToList());
//            _mockDbContext.AddressDeliveries.AddRange(newSeedData.AddressDeliveries);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetProducts()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.Products.RemoveRange(_mockDbContext.Products.ToList());
//            _mockDbContext.Products.AddRange(newSeedData.Products);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetImageProducts()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.ImageProducts.RemoveRange(_mockDbContext.ImageProducts.ToList());
//            _mockDbContext.ImageProducts.AddRange(newSeedData.Images);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetProductsOrders()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.ProductsOrders.RemoveRange(_mockDbContext.ProductsOrders.ToList());
//            _mockDbContext.ProductsOrders.AddRange(newSeedData.ProductsOrders);
//            _mockDbContext.SaveChanges();
//        }

//        public void ResetSections()
//        {
//            var newSeedData = new SeedData();
//            _mockDbContext.Sections.RemoveRange(_mockDbContext.Sections.ToList());
//            _mockDbContext.Sections.AddRange(newSeedData.Sections);
//            _mockDbContext.SaveChanges();
//        }

//        [OneTimeTearDown]
//        public void TearDownBase()
//        {
//            _mockDbContext.Dispose();
//        }
//    }
//}
