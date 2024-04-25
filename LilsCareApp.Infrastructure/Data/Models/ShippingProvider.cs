using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.ShippingProvider;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Shipping providers")]
    public class ShippingProvider
    {
        [Comment("Unique identifier of shipping provider")]
        [Key]
        public int Id { get; set; }


        [Comment("Name of shipping provider")]
        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }


        [Comment("Navigation property to shipping offices")]
        public List<ShippingOffice> ShippingOffices { get; set; } = [];

    }
}
