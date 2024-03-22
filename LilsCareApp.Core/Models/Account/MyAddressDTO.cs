namespace LilsCareApp.Core.Models.Account
{
    public class MyAddressDTO
    {
        public int AddressId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Country { get; set; } = string.Empty;

        public string? PostCode { get; set; } = string.Empty;

        public string? Town { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public string? District { get; set; }

        public string? Email { get; set; }

        public string? ShippingProvider { get; set; } = string.Empty;

        public string? OfficeCity { get; set; } = string.Empty;

        public string? OfficeAddress { get; set; } = string.Empty;

        public bool IsDefault { get; set; }

        public bool IsOffice { get; set; }
    }
}
