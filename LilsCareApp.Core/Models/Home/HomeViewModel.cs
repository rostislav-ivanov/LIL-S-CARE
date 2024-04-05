using System.ComponentModel.DataAnnotations;


namespace LilsCareApp.Core.Models.Home
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "Моля въведете вашия имейл!")]
        [EmailAddress(ErrorMessage = "Невалиден имейл.")]
        public string EmailSubscriber { get; set; } = string.Empty;

        [MustBeTrue(ErrorMessage = "Потвърдете съгласието с политиката за поверителност.")]
        public bool PrivacyPolicyCheckBox { get; set; }

        [Required(ErrorMessage = "Моля въведете вашето име!")]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Моля въведете вашия имейл!")]
        [EmailAddress]
        public string EmailForResponse { get; set; } = string.Empty;

        [Required(ErrorMessage = "Моля въведете съобщение!")]
        public string Message { get; set; } = string.Empty;

        [MustBeTrue(ErrorMessage = "Потвърдете съгласието с политиката за поверителност.")]
        public bool PrivacyPolicyCheckBoxForMessage { get; set; }

    }
}
