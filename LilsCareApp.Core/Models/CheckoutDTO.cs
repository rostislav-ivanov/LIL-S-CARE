using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

namespace LilsCareApp.Core.Models
{
    public class CheckoutDTO
    {
        public AddressDeliveryDTO? AddressDelivery { get; set; }
        public IEnumerable<AddressDeliveryDTO> AddressDeliveries { get; set; } = new List<AddressDeliveryDTO>();

        public ShippingProviderDTO? ShippingProvider { get; set; }

        public IEnumerable<ShippingProviderDTO> ShippingProviders { get; set; } = new List<ShippingProviderDTO>();

        public IEnumerable<ProductsInBagDTO> ProductsInBag { get; set; } = new List<ProductsInBagDTO>();

        public decimal SubTotal() => ProductsInBag.Sum(p => p.Quantity * p.Price);

        public decimal? ShippingPrice()
        {
            if (SubTotal() >= FreeShipping)
            {
                return 0;
            }
            else
            {
                return ShippingProvider?.Price;
            }
        }
    }
}
