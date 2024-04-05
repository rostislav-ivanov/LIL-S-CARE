using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models.Home
{
    public class SubscriberDTO
    {
        [Required(ErrorMessage = RequiredField)]
        [DisplayName("имейл")]
        [EmailAddress(ErrorMessage = InvalidEmailAddress)]
        public string EmailSubscriber { get; set; } = string.Empty;

        [MustBeTrue(ErrorMessage = PrivacyPolicyCheck)]
        public bool PrivacyPolicyCheckBox { get; set; }

        public string? AppUserId { get; set; }
    }
}
