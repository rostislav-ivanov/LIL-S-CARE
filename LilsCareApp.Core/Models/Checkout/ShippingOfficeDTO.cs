using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models.Checkout
{
    public class ShippingOfficeDTO
    {
        public int Id { get; set; }

        public int ShippingProviderId { get; set; }

        [Comment("City for Delivery")]
        [Required(ErrorMessage = Required)]
        [Display(Name = "град")]
        public string City { get; set; } = null!;

        [Comment("Office Address for Delivery")]
        [Required(ErrorMessage = Required)]
        [Display(Name = "адрес на офиса")]
        public string OfficeAddress { get; set; } = null!;

        public decimal Price { get; set; }


        [Comment("Duration of shipping")]
        public int ShippingDuration { get; set; }

    }
}