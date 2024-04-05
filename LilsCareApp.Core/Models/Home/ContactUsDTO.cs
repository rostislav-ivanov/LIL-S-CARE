using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models.Home
{
    public class ContactUsDTO
    {
        [Required(ErrorMessage = RequiredField)]
        [DisplayName("име")]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [DisplayName("имейл")]
        [EmailAddress(ErrorMessage = InvalidEmailAddress)]
        public string EmailForResponse { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [DisplayName("съобщение")]
        public string Message { get; set; } = string.Empty;

        [MustBeTrue(ErrorMessage = PrivacyPolicyCheck)]
        public bool PrivacyPolicy { get; set; }

        public string? AppUserId { get; set; }
    }
}
