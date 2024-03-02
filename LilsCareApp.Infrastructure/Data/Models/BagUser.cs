using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{

    [Comment("This table contains the products that the user has added to his bag")]
    [PrimaryKey("AppUserId", "ProductId")]
    public class BagUser
    {
        [Comment("The user id")]
        [Required]
        public required string AppUserId { get; set; }

        [Comment("Navigation property to the user that has added the product to his bag")]
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; } = null!;

        [Comment("The product id")]
        [Required]
        public int ProductId { get; set; }

        [Comment("Navigation property to the product that the user has added to his bag")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}