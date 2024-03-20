using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

namespace LilsCareApp.Core.Models.Checkout
{
    public class OrderDTO
    {
        public int? ShippingProviderId { get; set; }

        public IEnumerable<ShippingProviderDTO> ShippingProviders { get; set; } = new List<ShippingProviderDTO>();

        public IEnumerable<ProductsInBagDTO> ProductsInBag { get; set; } = new List<ProductsInBagDTO>();

        public AddressDeliveryDTO? AddressDelivery { get; set; }

        public IEnumerable<ShippingOfficeDTO> ShippingOffices { get; set; } = new List<ShippingOfficeDTO>();

        public int PaymentMethodId { get; set; } = 1;

        public int? PromoCodeId { get; set; }

        public IEnumerable<PromoCodeDTO> PromoCodes { get; set; } = new List<PromoCodeDTO>();

        public string NoteForDelivery { get; set; } = string.Empty;

        public bool IsWantToBeDefaultAddressDelivery { get; set; }

        public IEnumerable<string> ShippingCities { get; set; } = new List<string>();


        public bool IsShippingProvider() => ShippingProviderId != null;

        public bool IsDeliveryOffice() => AddressDelivery?.ShippingOffice?.Id != null && AddressDelivery.ShippingOffice.Id != 0;

        public bool IsDeliveryToAddress() => AddressDelivery != null && !AddressDelivery.IsShippingToOffice;

        public bool IsDeliveryToOffice() => AddressDelivery != null && AddressDelivery.IsShippingToOffice;

        public bool IsValidAddressDelivery() => AddressDelivery != null && AddressDelivery.IsValid;

        public bool IsValidOrder() => IsValidAddressDelivery();


        public decimal SubTotal() => ProductsInBag.Sum(p => p.Quantity * p.Price);

        public decimal Discount() => SubTotal() * PromoCodes.FirstOrDefault(p => p.Id == PromoCodeId)?.Discount ?? 0;

        public decimal? ShippingPrice()
        {
            if (SubTotal() >= FreeShipping)
            {
                return 0;
            }
            else if (IsDeliveryOffice())
            {
                return AddressDelivery.ShippingOffice?.Price;
            }
            else if (IsValidAddressDelivery())
            {
                return AddressDeliveryPrice;
            }
            else
            {
                return null;
            }
        }

        public decimal Total() => SubTotal() - Discount() + (ShippingPrice() ?? 0);


    }
}
