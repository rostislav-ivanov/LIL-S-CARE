using LilsCareApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models
{
    public class ContactUsDTO
    {
        [Required(ErrorMessage = Required)]
        [DisplayName("име")]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        [Required(ErrorMessage = Required)]
        [DisplayName("имейл")]
        [EmailAddress(ErrorMessage = InvalidEmailAddress)]
        public string EmailForResponse { get; set; } = string.Empty;

        [Required(ErrorMessage = Required)]
        [DisplayName("съобщение")]
        public string Message { get; set; } = string.Empty;

        [MustBeTrue(ErrorMessage = PrivacyPolicyCheck)]
        public bool PrivacyPolicy { get; set; }

        public string? AppUserId { get; set; }
    }
}
