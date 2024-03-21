using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ILilsCareService, LilsCareService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IDetailsService, DetailsService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddHttpContextAccessor();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".YourApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Session timeout duration
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // This is required for essential services to function properly
            });

            return services;
        }

        public static IServiceCollection AddAppIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
