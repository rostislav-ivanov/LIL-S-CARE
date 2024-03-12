using LilsCareApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models
{
    public class SubscriberDTO
    {
        [Required(ErrorMessage = Required)]
        [DisplayName("имейл")]
        [EmailAddress(ErrorMessage = EmailAddress)]
        public required string EmailSubscriber { get; set; }

        [MustBeTrue(ErrorMessage = PrivacyPolicyCheck)]
        public bool PrivacyPolicyCheckBox { get; set; }

        public string? AppUserId { get; set; }
    }
}
