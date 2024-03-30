using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Resources;
using LilsCareApp.Core.Services;
using LilsCareApp.Infrastructure.Data;
using LilsCareApp.Infrastructure.Data.Models;
using LilsCareApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
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

            services.AddOptions<AuthMessageSenderOptions>()
                    .Bind(configuration.GetSection("AuthMessageSenderOptions"));

            services.AddScoped<ILilsCareService, LilsCareService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IDetailsService, DetailsService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdminProductService, AdminProductService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddTransient<IEmailSender, EmailSender>();

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

        public static IServiceCollection AddAppLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                });
            services.AddMvc();

            return services;
        }

        public static IServiceCollection AddAppAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = "658708255927516";
                    options.AppSecret = "795acf9f3041cb193e8305bc94dcd6d9";
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "658708255927516";
                    options.ClientSecret = "795acf9f3041cb193e8305bc94dcd6d9";
                });

            return services;
        }

    }
}
