using LilsCareApp.Infrastructure.Data.DataConfiguration;
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

        public DbSet<ProductName> ProductNames { get; set; } = null!;

        public DbSet<ProductOptional> ProductOptionals { get; set; } = null!;

        public DbSet<SectionTitle> SectionTitles { get; set; } = null!;

        public DbSet<SectionDescription> SectionDescriptions { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<CategoryName> CategoryNames { get; set; } = null!;

        public DbSet<ProductCategory> ProductsCategories { get; set; } = null!;

        public DbSet<ImageProduct> ImageProducts { get; set; } = null!;

        public DbSet<ImageReview> ImageReviews { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<ProductOrder> ProductsOrders { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<StatusOrderName> StatusOrderNames { get; set; } = null!;

        public DbSet<StatusOrder> StatusOrders { get; set; } = null!;

        public DbSet<ShippingProvider> ShippingProviders { get; set; } = null!;

        public DbSet<PaymentType> PaymentTypes { get; set; } = null!;

        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

        public DbSet<AddressDelivery> AddressDeliveries { get; set; } = null!;

        public DbSet<WishUser> WishesUsers { get; set; } = null!;

        public DbSet<BagUser> BagsUsers { get; set; } = null!;

        public DbSet<Subscriber> Subscribers { get; set; } = null!;

        public DbSet<MessageFromClient> MessagesFromClients { get; set; } = null!;

        public DbSet<ShippingOffice> ShippingOffices { get; set; } = null!;

        public DbSet<PromoCodeName> PromoCodeNames { get; set; } = null!;

        public DbSet<PromoCode> PromoCodes { get; set; } = null!;

        public DbSet<Section> Sections { get; set; } = null!;

        public DbSet<AppConfig> AppConfigs { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ImageReview>()
                .HasOne(ir => ir.Review)
                .WithMany(r => r.Images)
                .HasForeignKey(ir => new { ir.ProductId, ir.AuthorId });

            builder.Entity<AppUser>()
                .HasMany(au => au.AddressDelivery)
                .WithOne(ad => ad.AppUser)
                .HasForeignKey(ad => ad.AppUserId);

            builder.Entity<AppUser>()
                .HasOne(au => au.DefaultAddressDelivery)
                .WithMany()
                .HasForeignKey(au => au.DefaultAddressDeliveryId)
                .IsRequired(false);


            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new ProductNamesConfiguration());
            builder.ApplyConfiguration(new ProductOptionalConfiguration());
            builder.ApplyConfiguration(new SectionTitleConfiguration());
            builder.ApplyConfiguration(new SectionDescriptionConfiguration());
            builder.ApplyConfiguration(new CategoriesConfiguration());
            builder.ApplyConfiguration(new CategoryNamesConfiguration());
            builder.ApplyConfiguration(new ProductsConfiguration());
            builder.ApplyConfiguration(new ProductsCategoriesConfiguration());
            builder.ApplyConfiguration(new SectionsConfiguration());
            builder.ApplyConfiguration(new WishesUsersConfiguration());
            builder.ApplyConfiguration(new BagsUsersConfiguration());
            builder.ApplyConfiguration(new ShippingOfficeConfiguration());
            builder.ApplyConfiguration(new StatusOrdersNameConfiguration());
            builder.ApplyConfiguration(new StatusOrdersConfiguration());
            builder.ApplyConfiguration(new ShippingProvidersConfiguration());
            builder.ApplyConfiguration(new PaymentTypesConfiguration());
            builder.ApplyConfiguration(new PaymentMethodsConfiguration());
            builder.ApplyConfiguration(new AddressDeliveriesConfiguration());
            builder.ApplyConfiguration(new OrdersConfiguration());
            builder.ApplyConfiguration(new ProductsOrdersConfiguration());
            builder.ApplyConfiguration(new ReviewsConfiguration());
            builder.ApplyConfiguration(new ImageProductsConfiguration());
            builder.ApplyConfiguration(new PromoCodeNameConfiguration());
            builder.ApplyConfiguration(new PromoCodeConfiguration());
            builder.ApplyConfiguration(new AppConfigConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
