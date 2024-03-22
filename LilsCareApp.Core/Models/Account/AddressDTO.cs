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
        [MaxLength(PhoneNumberMaxLength)]
        [Required(ErrorMessage = Required)]
        [RegularExpression(PhoneNumberPattern, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "телефонен номер")]
        public string PhoneNumber { get; set; } = string.Empty;


        [Comment("Country")]
        [Required(ErrorMessage = Required)]
        [MaxLength(CountryMaxLength)]
        [Display(Name = "държава")]
        public string Country { get; set; } = string.Empty;

        [Comment("Post Code")]
        [Required(ErrorMessage = Required)]
        [MaxLength(PostCodeMaxLength)]
        [Display(Name = "пощенски код")]
        public string PostCode { get; set; } = string.Empty;

        [Comment("Town")]
        [Required(ErrorMessage = Required)]
        [MaxLength(TownMaxLength)]
        [Display(Name = "град")]
        public string Town { get; set; } = string.Empty;

        [Comment("Address")]
        [Required(ErrorMessage = Required)]
        [MaxLength(AddressMaxLength)]
        [Display(Name = "адрес")]
        public string Address { get; set; } = string.Empty;

        [MaxLength(DistrictMaxLength)]
        [Comment("District")]
        public string? District { get; set; }

        [Comment("Email Address not required")]
        [MaxLength(EmailNumberMaxLength)]
        [RegularExpression(EmailPatternNotRequired, ErrorMessage = InvalidEmailAddress)]
        [Display(Name = "имейл")]
        public string? Email { get; set; }
    }
}
