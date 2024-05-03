using LilsCareApp.Core.Resources;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models.Home
{
    public class ContactUsDTO
    {
        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "FirstName", ResourceType = typeof(SharedResource))]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "LastName", ResourceType = typeof(SharedResource))]
        public string? LastName { get; set; }

        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [RegularExpression(
            EmailPatternNotRequired,
            ErrorMessageResourceName = "InvalidEmailAddress",
            ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Email", ResourceType = typeof(SharedResource))]
        public string EmailForResponse { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Message", ResourceType = typeof(SharedResource))]
        public string Message { get; set; } = string.Empty;

        [MustBeTrue(ErrorMessageResourceName = "PrivacyPolicyCheck", ErrorMessageResourceType = typeof(SharedResource))]
        public bool PrivacyPolicy { get; set; }

        public string? AppUserId { get; set; }
    }
}
