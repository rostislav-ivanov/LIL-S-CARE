using LilsCareApp.Core.Models.Account;
using LilsCareApp.Infrastructure.Data.Models;
using static LilsCareApp.Infrastructure.DataConstants.AppConstants;

namespace LilsCareApp.Core.Models.Checkout
{
    public class OrderDTO : DeliveryAddressesDTO
    {
        public IEnumerable<ProductsInBagDTO> ProductsInBag { get; set; } = [];

        public int PaymentMethodId { get; set; } = 1;

        public IEnumerable<PaymentMethod> PaymentMethods { get; set; } = [];

        public int? PromoCodeId { get; set; }

        public IEnumerable<PromoCodeDTO> PromoCodes { get; set; } = [];

        public string? NoteForDelivery { get; set; }

        public bool IsValidOrder { get; set; }

        // Get the payment method type
        public string? PaymentMethod() => PaymentMethods.FirstOrDefault(p => p.Id == PaymentMethodId)?.Type.NameBG;

        // Calculate the discount of the order
        public decimal Discount() => ProductsInBag.Sum(p => p.Quantity * p.Price) * PromoCodes.FirstOrDefault(p => p.Id == PromoCodeId)?.Discount ?? 0;

        // Calculate the subtotal of the order
        public decimal SubTotal() => ProductsInBag.Sum(p => p.Quantity * p.Price) - Discount();


        // Get shipping price based on the delivery type and subtotal.
        // If the subtotal is greater than or equal to FreeShipping, shipping price is 0.
        public decimal? ShippingPrice()
        {
            if (SubTotal() >= FreeShipping)
            {
                return 0;
            }
            else if (DeliveryType() == OfficeDeliveryType)
            {
                return Office?.Price();
            }
            else if (DeliveryType() == AddressDeliveryType)
            {
                return AddressDeliveryPrice;
            }
            else
            {
                return null;
            }
        }

        // Calculate the total of the order
        public decimal Total() => SubTotal() + (ShippingPrice() ?? 0);
    }
}
