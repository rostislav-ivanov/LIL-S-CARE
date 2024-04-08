using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.AppUser;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("App User")]
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(UserNameMaxLength)]
        public override required string UserName { get; set; }

        [Comment("First Name")]
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        [Comment("Last Name")]
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

        [Comment("The image of user")]
        [MaxLength(ImagePathMaxLength)]
        public string? ImagePath { get; set; }

        [Comment("Navigation property to Order")]
        public List<Order> Orders { get; set; } = new List<Order>();

        [Comment("Navigation property to mapping table WishUser")]
        List<WishUser> WishesUsers { get; set; } = new List<WishUser>();

        [Comment("Navigation property to mapping table BagUser")]
        List<BagUser> BagsUsers { get; set; } = new List<BagUser>();

        [Comment("Navigation property to Review")]
        List<Review> Reviews { get; set; } = new List<Review>();


        [Comment("Default Address Delivery Id")]
        public int? DefaultAddressDeliveryId { get; set; }

        [Comment("Navigation property to AddressDelivery")]
        [ForeignKey(nameof(DefaultAddressDeliveryId))]
        public AddressDelivery? DefaultAddressDelivery { get; set; }


        [Comment("Navigation property to AddressDelivery")]
        public List<AddressDelivery> AddressDelivery { get; set; } = new List<AddressDelivery>();

        [Comment("Navigation property to PromoCode")]
        public List<PromoCode> PromoCodes { get; set; } = new List<PromoCode>();
    }
}



