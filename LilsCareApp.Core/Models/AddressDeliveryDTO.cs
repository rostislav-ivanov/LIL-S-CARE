using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;
namespace LilsCareApp.Core.Models
{
    public class AddressDeliveryDTO
    {
        [Key]
        [Comment("Address Id")]
        public int Id { get; set; }

        [Comment("First Name Recipient")]
        [Required(ErrorMessage = Required)]
        [MaxLength(FirstNameMaxLength)]
        [Display(Name = "име")]
        public string FirstName { get; set; } = string.Empty;

        [Comment("Last Name Recipient")]
        [Required(ErrorMessage = Required)]
        [MaxLength(LastNameMaxLength)]
        [Display(Name = "фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Comment("Phone Number Recipient")]
        [Required(ErrorMessage = Required)]
        [MaxLength(PhoneNumberMaxLength)]
        [RegularExpression(PhoneNumberPattern, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "телефонен номер")]
        public string PhoneNumber { get; set; } = string.Empty;

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

        [Comment("Email Address")]
        public string Email { get; set; } = string.Empty;

    }
}