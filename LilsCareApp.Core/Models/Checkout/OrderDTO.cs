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


        public bool IsDeliveryLocation() => AddressDelivery?.IsValid != false || OfficeDelivery?.IsValid != false;

        public bool IsShippingProvider() => ShippingProviderId != null;

        public bool IsValidOrder() => IsDeliveryLocation() && IsShippingProvider();

        public string? DeliveryType() => ShippingProviders.FirstOrDefault(sp => sp.Id == ShippingProviderId)?.Description;

        //public decimal SubTotal() => ProductsInBag.Sum(p => p.Quantity * p.Price);

        //public decimal? ShippingPrice()
        //{
        //    if (SubTotal() >= FreeShipping)
        //    {
        //        return 0;
        //    }
        //    else if (AddressDelivery != null && AddressDelivery.IsValid)
        //    {
        //        return AddressDelivery.Price;
        //    }
        //    else if (OfficeDelivery != null && OfficeDelivery.IsValid)
        //    {
        //        return OfficeDelivery.Office?.Price;
        //    }
        //    else
        //        return null;
        //}

        //public bool IsValid() => DeliveryType != null && (DeliveryType.IsDeliveryToAddress ? AddressDelivery?.IsValid : OfficeDelivery?.IsValid) == true;

        //public decimal? Total() => SubTotal() + ShippingPrice();


    }
}
