using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static LilsCareApp.Infrastructure.DataConstants.AdminConstants;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var service = serviceScope.ServiceProvider;

            var userManager = service.GetRequiredService<UserManager<AppUser>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                var adminRole = new IdentityRole { Name = "Admin" };

                if (!await roleManager.RoleExistsAsync(adminRole.Name))
                {
                    await roleManager.CreateAsync(adminRole);
                }

                var adminUser = await userManager.FindByNameAsync(AdminEmail);

                if (adminUser != null)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole.Name);
                }
            })
            .GetAwaiter().GetResult();

            return app;
        }
    }
}
