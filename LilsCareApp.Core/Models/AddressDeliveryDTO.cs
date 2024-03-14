using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;

namespace LilsCareApp.Core.Models
{
    public class AddressDeliveryDTO
    {
        [Key]
        [Comment("Address Id")]
        public int Id { get; set; }

        [MaxLength(FirstNameMaxLength)]
        [Comment("First Name Recipient")]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Comment("Last Name Recipient")]
        public string? LastName { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Phone Number Recipient")]
        public string? PhoneNumber { get; set; }

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

        [Comment("App User Id")]
        public string? AppUserId { get; set; }

    }
}