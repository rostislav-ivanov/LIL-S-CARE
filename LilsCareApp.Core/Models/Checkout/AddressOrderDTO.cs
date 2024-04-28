using LilsCareApp.Core.Resources;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;

namespace LilsCareApp.Core.Models.Checkout
{
    public class AddressOrderDTO
    {
        [Key]
        [Comment("Address Id")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [MaxLength(FirstNameMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "FirstName", ResourceType = typeof(SharedResource))]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [MaxLength(LastNameMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "LastName", ResourceType = typeof(SharedResource))]
        public string LastName { get; set; } = string.Empty;


        [MaxLength(PhoneNumberMaxLength)]
        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [RegularExpression(
            PhoneNumberPattern,
            ErrorMessageResourceName = "InvalidPhoneNumber",
            ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "PhoneNumber", ResourceType = typeof(SharedResource))]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [MaxLength(CountryMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Country", ResourceType = typeof(SharedResource))]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [MaxLength(PostCodeMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "PostCode", ResourceType = typeof(SharedResource))]
        public string PostCode { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [MaxLength(TownMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Town", ResourceType = typeof(SharedResource))]
        public string Town { get; set; } = string.Empty;

        [Required(ErrorMessageResourceName = "ResourceRequired", ErrorMessageResourceType = typeof(SharedResource))]
        [MaxLength(AddressMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Address", ResourceType = typeof(SharedResource))]
        public string Address { get; set; } = string.Empty;

        [MaxLength(DistrictMaxLength, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(SharedResource))]
        public string? District { get; set; }

        [MaxLength(EmailMaxLength)]
        [RegularExpression(
            EmailPatternNotRequired,
            ErrorMessageResourceName = "InvalidEmailAddress",
            ErrorMessageResourceType = typeof(SharedResource))]
        [Display(Name = "Email", ResourceType = typeof(SharedResource))]
        public string? Email { get; set; }

        public int? ShippingOfficeId { get; set; }

        public ShippingOfficeDTO? ShippingOffice { get; set; }

        public int ShippingProviderId { get; set; }

        public IEnumerable<ShippingProviderDTO> ShippingProviders { get; set; } = [];

        public string ShippingProviderCity { get; set; } = string.Empty;

        public IEnumerable<string> ShippingProviderCities { get; set; } = [];

        public IEnumerable<ShippingOfficeDTO> ShippingOffices { get; set; } = [];

        public bool IsDefault { get; set; }

        public int DeliveryMethodId { get; set; }
    }
}
