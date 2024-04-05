using LilsCareApp.Core.Resources;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;

namespace LilsCareApp.Core.Models.Account
{
    public class AddressDTO
    {
        [Key]
        [Comment("Address Id")]
        public int Id { get; set; }

        [Comment("First Name Recipient")]
        //[Required(ErrorMessage = Required)]
        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [MaxLength(FirstNameMaxLength)]
        [Display(Name = "FirstName", ResourceType = typeof(SharedResource))]
        public string FirstName { get; set; } = string.Empty;

        [Comment("Last Name Recipient")]
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(LastNameMaxLength)]
        [Display(Name = "LastName", ResourceType = typeof(SharedResource))]
        public string LastName { get; set; } = string.Empty;


        [Comment("Phone Number Recipient")]
        [MaxLength(PhoneNumberMaxLength)]
        [Required(ErrorMessage = RequiredField)]
        [RegularExpression(PhoneNumberPattern, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "PhoneNumber", ResourceType = typeof(SharedResource))]
        public string PhoneNumber { get; set; } = string.Empty;


        [Comment("Country")]
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(CountryMaxLength)]
        [Display(Name = "Country", ResourceType = typeof(SharedResource))]
        public string Country { get; set; } = string.Empty;

        [Comment("Post Code")]
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(PostCodeMaxLength)]
        [Display(Name = "PostCode", ResourceType = typeof(SharedResource))]
        public string PostCode { get; set; } = string.Empty;

        [Comment("Town")]
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(TownMaxLength)]
        [Display(Name = "Town", ResourceType = typeof(SharedResource))]
        public string Town { get; set; } = string.Empty;

        [Comment("Address")]
        [Required(ErrorMessage = RequiredField)]
        [MaxLength(AddressMaxLength)]
        [Display(Name = "Address", ResourceType = typeof(SharedResource))]
        public string Address { get; set; } = string.Empty;

        [MaxLength(DistrictMaxLength)]
        [Comment("District")]
        public string? District { get; set; }

        [Comment("Email Address not required")]
        [MaxLength(EmailNumberMaxLength)]
        [RegularExpression(
            EmailPatternNotRequired,
            ErrorMessageResourceName = "InvalidEmailAddress",
            ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Email", ResourceType = typeof(SharedResource))]
        public string? Email { get; set; }
    }
}
