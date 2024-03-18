using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;
namespace LilsCareApp.Core.Models.Checkout
{
    public class AddressDeliveryDTO : IDeliveryDTO
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


        [Comment("Country")]
        [Required(ErrorMessage = Required)]
        [MaxLength(CountryMaxLength)]
        [Display(Name = "държава")]
        public string? Country { get; set; }

        [Comment("Post Code")]
        [Required(ErrorMessage = Required)]
        [MaxLength(PostCodeMaxLength)]
        [Display(Name = "пощенски код")]
        public string? PostCode { get; set; }

        [Comment("Town")]
        [Required(ErrorMessage = Required)]
        [MaxLength(TownMaxLength)]
        [Display(Name = "град")]
        public string? Town { get; set; }

        [Comment("Address")]
        [Required(ErrorMessage = Required)]
        [MaxLength(AddressMaxLength)]
        [Display(Name = "адрес")]
        public string? Address { get; set; }

        [MaxLength(DistrictMaxLength)]
        [Comment("District")]
        public string? District { get; set; }

        [Comment("Phone Number Recipient not required")]
        [MaxLength(PhoneNumberMaxLength)]
        [RegularExpression(PhoneNumberPatternNotRequired, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "телефонен номер")]
        public string? PhoneNumber { get; set; }


        [Comment("Email Address not required")]
        [MaxLength(EmailNumberMaxLength)]
        [RegularExpression(EmailPatternNotRequired, ErrorMessage = InvalidEmailAddress)]
        [Display(Name = "имейл")]
        public string? Email { get; set; }

        public int? ShippingProviderId { get; set; }
        public ShippingProviderDTO? ShippingProvider { get; set; }

        public bool IsValid { get; set; } = false;
        public bool IsShippingToOffice { get; set; } = false;
    }
}