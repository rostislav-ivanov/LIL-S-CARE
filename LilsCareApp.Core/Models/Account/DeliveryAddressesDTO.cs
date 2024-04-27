//namespace LilsCareApp.Core.Models.Account
//{
//    public class DeliveryAddressesDTO
//    {
//        public readonly string AddressDeliveryType = "Доставка до адрес на клиент";

//        public readonly string OfficeDeliveryType = "Доставка до офис на куриер";

//        public AddressDTO? Address { get; set; }

//        public OfficeDTO? Office { get; set; }


//        // Returns true if Address or Office is selected
//        public bool IsSelectedDeliveryType() => Address != null || Office != null;

//        // Returns the delivery type:
//        // If no delivery type is selected,
//        // AddressDeliveryType if Address is selected,
//        // OfficeDeliveryType if Office is selected
//        public string? DeliveryType() => IsSelectedDeliveryType() ? Address != null ? AddressDeliveryType : OfficeDeliveryType : null;

//    }
//}
