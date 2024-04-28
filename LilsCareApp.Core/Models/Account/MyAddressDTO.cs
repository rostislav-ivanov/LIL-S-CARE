using LilsCareApp.Core.Resources;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AppUser;

namespace LilsCareApp.Core.Models.Account
{
    public class MyAddressDTO
    {
        public required string UserName { get; set; }


        [MaxLength(FirstNameMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "FirstName", ResourceType = typeof(SharedResource))]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "LastName", ResourceType = typeof(SharedResource))]
        public string? LastName { get; set; }

        [MaxLength(EmailMaxLength)]
        [RegularExpression(
            EmailPatternNotRequired,
            ErrorMessageResourceName = "InvalidEmailAddress",
            ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Email", ResourceType = typeof(SharedResource))]
        public string? Email { get; set; }

        [RegularExpression(
            PhoneNumberPattern,
            ErrorMessageResourceName = "InvalidPhoneNumber",
            ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "PhoneNumber", ResourceType = typeof(SharedResource))]
        public string? PhoneNumber { get; set; }

        [MaxLength(ImagePathMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Photo", ResourceType = typeof(SharedResource))]
        public string? ImagePath { get; set; }


    }
}
