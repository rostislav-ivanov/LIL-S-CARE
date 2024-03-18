using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("App User")]
    public class AppUser : IdentityUser
    {

        [Comment("The image of user")]
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
    }
}



