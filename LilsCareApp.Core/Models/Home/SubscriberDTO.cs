using LilsCareApp.Core.Resources;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models.Home
{
    public class SubscriberDTO
    {
        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [RegularExpression(
            EmailPatternNotRequired,
            ErrorMessageResourceName = "InvalidEmailAddress",
            ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Email", ResourceType = typeof(SharedResource))]
        public string EmailSubscriber { get; set; } = string.Empty;

        [MustBeTrue(ErrorMessageResourceName = "PrivacyPolicyCheck", ErrorMessageResourceType = typeof(SharedResource))]
        public bool PrivacyPolicyCheckBox { get; set; }

        public string? AppUserId { get; set; }
    }
}
