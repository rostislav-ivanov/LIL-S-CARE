using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public static AppUser AppUser = GetAppUser();



        private static AppUser GetAppUser()
        {
            var hasher = new PasswordHasher<AppUser>();

            AppUser user = new AppUser
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            user.PasswordHash = hasher.HashPassword(user, "softuni");

            return user;
        }
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(ConfigurationHelper.AppUser);
        }
    }
}