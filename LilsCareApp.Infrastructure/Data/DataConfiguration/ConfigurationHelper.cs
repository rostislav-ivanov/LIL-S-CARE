using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    [Comment("This class is used to seed the database with a default user.")]
    public static class ConfigurationHelper
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
    }
}
