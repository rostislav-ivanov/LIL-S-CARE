using static LilsCareApp.Infrastructure.DataConstants.AppConstants;
namespace LilsCareApp.Core.Models.Checkout
{
    public class OrderDTO
    {
        public int? ShippingProviderId { get; set; }

        public IEnumerable<ShippingProviderDTO> ShippingProviders { get; set; } = new List<ShippingProviderDTO>();

        public IEnumerable<ShippingOfficeDTO> ShippingOffices { get; set; } = new List<ShippingOfficeDTO>();

        public AddressDeliveryDTO? AddressDelivery { get; set; }

        public OfficeDeliveryDTO? OfficeDelivery { get; set; }

        public IEnumerable<ProductsInBagDTO> ProductsInBag { get; set; } = new List<ProductsInBagDTO>();

        public string NoteForDelivery { get; set; } = string.Empty;

        public bool IsWantToBeDefaultAddressDelivery { get; set; }

        public IEnumerable<string> ShippingCities { get; set; } = new List<string>();

        public bool IsAddressDelivery() => ShippingProviderId == 0;

        public bool IsOfficeDelivery() => ShippingProviderId > 0;


        public bool IsDeliveryValid() => AddressDelivery?.IsValid != false || OfficeDelivery?.IsValid != false;

        public bool IsShippingProvider() => ShippingProviderId != null;

        public bool IsValidOrder() => IsDeliveryValid() && IsShippingProvider();

        public string? DeliveryType() => ShippingProviders.FirstOrDefault(sp => sp.Id == ShippingProviderId)?.Description;

        public decimal SubTotal() => ProductsInBag.Sum(p => p.Quantity * p.Price);

        public decimal? ShippingPrice()
        {
            if (SubTotal() >= FreeShipping)
            {
                return 0;
            }
            else if (AddressDelivery != null && AddressDelivery.IsValid)
            {
                return AddressDeliveryPrice;
            }
            else if (OfficeDelivery != null && OfficeDelivery.IsValid)
            {
                return OfficeDelivery.ShippingOffice?.Price;
            }
            else
                return null;
        }

        public decimal? Total() => SubTotal() + ShippingPrice();


    }
}
