using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

namespace LilsCareApp.Core.Models
{
    public class CheckoutDTO
    {
        public DeliveryTypeDTO? DeliveryType { get; set; }
        public IEnumerable<DeliveryTypeDTO> DeliveryTypes { get; set; } = new List<DeliveryTypeDTO>();
        public AddressDeliveryDTO? AddressDelivery { get; set; }
        //public IEnumerable<AddressDeliveryDTO> AddressDeliveries { get; set; } = new List<AddressDeliveryDTO>();
        public OfficeDeliveryDTO? OfficeDelivery { get; set; }

        public IEnumerable<ProductsInBagDTO> ProductsInBag { get; set; } = new List<ProductsInBagDTO>();

        public decimal SubTotal() => ProductsInBag.Sum(p => p.Quantity * p.Price);

        public decimal? ShippingPrice()
        {
            if (SubTotal() >= FreeShipping)
            {
                return 0;
            }
            else if (AddressDelivery != null && AddressDelivery.IsValid)
            {
                return AddressDelivery.Price;
            }
            else if (OfficeDelivery != null && OfficeDelivery.IsValid)
            {
                return OfficeDelivery.Office?.Price;
            }
            else
                return null;
        }

        public bool IsValid() => DeliveryType != null && (DeliveryType.IsDeliveryToAddress ? AddressDelivery?.IsValid : OfficeDelivery?.IsValid) == true;

        public decimal? Total() => SubTotal() + ShippingPrice();


    }
}
