using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AppUser;

namespace LilsCareApp.Core.Models.Account
{
    public class MyAddressDTO
    {
        public required string UserName { get; set; }

        [MaxLength(FirstNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "име")]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "фамилия")]
        public string? LastName { get; set; }

        [MaxLength(EmailMaxLength, ErrorMessage = StringLengthMax)]
        [RegularExpression(EmailPatternNotRequired, ErrorMessage = InvalidEmailAddress)]
        [Display(Name = "имейл")]
        public string? Email { get; set; }

        [RegularExpression(PhoneNumberPatternNotRequired, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "телефонен номер")]
        public string? PhoneNumber { get; set; }

        [MaxLength(ImagePathMaxLength, ErrorMessage = StringLengthMax)]
        [Display(Name = "снимка")]
        public string? ImagePath { get; set; }


    }
}
