using LilsCareApp.Core.Configurations;
using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
                options.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }));

            services.AddOptions<AuthMessageSenderOptions>()
                    .Bind(configuration.GetSection("AuthMessageSenderOptions"));

            services.AddScoped<IAppConfigService, AppConfigService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IDetailsService, DetailsService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdminProductService, AdminProductService>();
            services.AddScoped<IAdminDetailsService, AdminDetailsService>();
            services.AddScoped<IAdminOrderService, AdminOrderService>();
            services.AddScoped<IAdminOrderDetailsService, AdminOrderDetailsService>();
            services.AddScoped<IHttpContextManager, HttpContextManager>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IShippingProviderService, ShippingProviderService>();

            services.AddHttpContextAccessor();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".LilsCare.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(120); // Session timeout duration
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // This is required for essential services to function properly
            });

            return services;
        }

        public static IServiceCollection AddAppIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddAppAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
            .AddFacebook(options =>
            {
                options.AppId = configuration.GetValue<string>("FacebookAuth:AppId") ?? throw new InvalidOperationException
                 ("Facebook AppId is not found in appsettings.json");
                options.AppSecret = configuration.GetValue<string>("FacebookAuth:AppSecret") ?? throw new InvalidOperationException
                 ("Facebook AppSecret is not found in appsettings.json");
            })
            .AddGoogle(options =>
            {
                options.ClientId = configuration.GetValue<string>("GoogleAuth:ClientId") ?? throw new InvalidOperationException
                    ("Google ClientId is not found in appsettings.json");
                options.ClientSecret = configuration.GetValue<string>("GoogleAuth:ClientSecret") ?? throw new InvalidOperationException
                    ("Google ClientSecret is not found in appsettings.json");
            });

            return services;
        }

    }
}
