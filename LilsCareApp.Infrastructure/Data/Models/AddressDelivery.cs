using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;

namespace LilsCareApp.Infrastructure.Data.Models
{

    [Comment("Address Delivery")]
    public class AddressDelivery
    {
        [Key]
        [Comment("Address Id")]
        public int Id { get; set; }

        [MaxLength(FirstNameMaxLength)]
        [Comment("First Name Recipient")]
        public required string FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Comment("Last Name Recipient")]
        public required string LastName { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Phone Number Recipient")]
        public required string PhoneNumber { get; set; }

        [MaxLength(PostCodeMaxLength)]
        [Comment("Post Code")]
        public string? PostCode { get; set; }

        [MaxLength(AddressMaxLength)]
        [Comment("Address")]
        public string? Address { get; set; }

        [MaxLength(TownMaxLength)]
        [Comment("Town")]
        public string? Town { get; set; }

        [MaxLength(DistrictMaxLength)]
        [Comment("District")]
        public string? District { get; set; }

        [MaxLength(CountryMaxLength)]
        [Comment("Country")]
        public string? Country { get; set; }

        [MaxLength(EmailMaxLength)]
        [Comment("Email")]
        public string? Email { get; set; }

        public bool IsShippingToOffice { get; set; }

        public int? ShippingOfficeId { get; set; }

        [ForeignKey(nameof(ShippingOfficeId))]
        [Comment("Navigation property to ShippingOffice")]
        public ShippingOffice? ShippingOffice { get; set; }

        [Comment("Navigation property to Order")]
        public List<Order> Orders { get; set; } = new List<Order>();


        [Comment("App User Id")]
        public string? AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        [Comment("Navigation property to AppUser")]
        public AppUser AppUser { get; set; } = null!;
    }
}

