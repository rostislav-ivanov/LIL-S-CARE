using LilsCareApp.Core.Models.Checkout;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.AddressDelivery;

namespace LilsCareApp.Core.Models.Account
{
    public class OfficeDTO
    {
        [Key]
        [Comment("Address Id")]
        public int Id { get; set; }

        public int? ShippingProviderId { get; set; }
        public IEnumerable<ShippingProviderDTO> ShippingProviders { get; set; } = [];

        public string? CityName { get; set; }

        public IEnumerable<string> ShippingProviderCities { get; set; } = [];

        public int? ShippingOfficeId { get; set; }

        public IEnumerable<ShippingOfficeDTO> ShippingOffices { get; set; } = [];


        public string? Provider() => ShippingProviders.Where(sp => sp.Id == ShippingProviderId).Select(sp => sp.Name).FirstOrDefault();


        public string? OfficeAddress() => ShippingOffices.Where(so => so.Id == ShippingOfficeId).Select(so => so.OfficeAddress).FirstOrDefault();

        public string? City() => ShippingOffices.Where(so => so.Id == ShippingOfficeId).Select(so => so.City).FirstOrDefault();

        public decimal? Price() => ShippingOffices.Where(so => so.Id == ShippingOfficeId).Select(so => so.Price).FirstOrDefault();

        public bool IsSelectedOffice() => Provider() != null && City() != null && OfficeAddress() != null;


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
        [MaxLength(PhoneNumberMaxLength)]
        [Required(ErrorMessage = Required)]
        [RegularExpression(PhoneNumberPattern, ErrorMessage = InvalidPhoneNumber)]
        [Display(Name = "телефонен номер")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
