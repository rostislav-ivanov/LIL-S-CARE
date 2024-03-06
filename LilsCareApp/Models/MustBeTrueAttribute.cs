using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Models.ErrorMessageConstants;

namespace LilsCareApp.Models
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is bool && (bool)value)
                return ValidationResult.Success;
            return new ValidationResult(ConfirmAgreementPrivacyPolicy);
        }
    }
}
