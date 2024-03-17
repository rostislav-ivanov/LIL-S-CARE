using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;

namespace LilsCareApp.Core.Models
{
    public class OfficeDeliveryDTO
    {
        public int Id { get; set; }
        public int DeliverId { get; set; }

        public OfficeDTO? Office { get; set; }

        public List<OfficeDTO> Offices { get; set; } = new List<OfficeDTO>();

        [Comment("First Name Recipient")]
        [Required(ErrorMessage = Required)]
        [MaxLength(FirstNameMaxLength)]
        [Display(Name = "име")]
        public string FirstName { get; set; } = string.Empty;

        [Comment("Last Name Recipient")]
        [Required(ErrorMessage = Required)]
        [MaxLength(LastNameMaxLength)]
        [Display(Name = "фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Comment("Phone Number Recipient")]
        [Required(ErrorMessage = Required)]
        [MaxLength(PhoneNumberMaxLength)]
        [RegularExpression(PhoneNumberPattern, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "телефонен номер")]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsValid { get; set; } = false;

    }
}