using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.Image;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The image of the product")]
    public class ImageProduct
    {
        [Comment("The image id")]
        [Key]
        public int Id { get; set; }

        [Comment("The path of the image")]
        [Required]
        [MaxLength(ImagePathMaxLength)]
        public required string ImagePath { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Comment("Navigation to the products that the image is for")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
