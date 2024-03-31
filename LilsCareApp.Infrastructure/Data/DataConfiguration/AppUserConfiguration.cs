using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static LilsCareApp.Infrastructure.DataConstants.AdminConstants;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        private readonly IEnumerable<AppUser> users = new List<AppUser>()
        {
            new AppUser
            {
                Id = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG",
                Email = "test@softuni.bg",
                NormalizedEmail = "TEST@SOFTUNI.BG",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "Testov",
            },
            new AppUser
            {
                Id = "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Adminov",
            }
        };


        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            var hasher = new PasswordHasher<AppUser>();

            users.First().PasswordHash = hasher.HashPassword(users.First(), "softuni");
            users.Last().PasswordHash = hasher.HashPassword(users.Last(), "softuni-admin");

            builder.HasData(users);
        }
    }
}