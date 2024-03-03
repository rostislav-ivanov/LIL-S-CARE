using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<ProductsCategories> ProductsCategories { get; set; } = null!;

        public DbSet<Image> Images { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<StatusOrder> StatusOrders { get; set; } = null!;

        public DbSet<ShippingProvider> ShippingProviders { get; set; } = null!;

        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

        public DbSet<AddressDelivery> AddressDeliveries { get; set; } = null!;

        public DbSet<WishUser> WishesUsers { get; set; } = null!;

        public DbSet<BagUser> BagsUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
