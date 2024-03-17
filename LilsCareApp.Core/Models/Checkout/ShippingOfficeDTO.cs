using Microsoft.EntityFrameworkCore;

namespace LilsCareApp.Core.Models.Checkout
{
    public class ShippingOfficeDTO
    {
        public int Id { get; set; }

        public string? City { get; set; }


        public string? OfficeAddress { get; set; }

        public decimal Price { get; set; }


        [Comment("Duration of shipping")]
        public int ShippingDuration { get; set; }

    }
}