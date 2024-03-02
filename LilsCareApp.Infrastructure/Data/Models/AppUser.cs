using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("App User")]
    public class AppUser : IdentityUser
    {
        [Comment("Image App User")]
        public int? ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        [Comment("Navigation property to Image")]
        public Image? Image { get; set; }

        [Comment("Navigation property to AddressDelivery")]
        public List<AddressDelivery> AddressDelivery { get; set; } = new List<AddressDelivery>();

        [Comment("Navigation property to Order")]
        public List<Order> Orders { get; set; } = new List<Order>();

        [Comment("Navigation property to mapping table WishUser")]
        List<WishUser> WishesUsers { get; set; } = new List<WishUser>();

        [Comment("Navigation property to mapping table BagUser")]
        List<BagUser> BagsUsers { get; set; } = new List<BagUser>();

    }
}



