using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LilsCareApp.Infrastructure.DataConstants.Image;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The image of the product or review or user")]
    public class Image
    {
        [Comment("The image id")]
        [Key]
        public int Id { get; set; }

        [Comment("The path of the image")]
        [Required]
        [MaxLength(ImagePathMaxLength)]
        public required string ImagePath { get; set; }

        [Comment("The product id")]
        public int? ProductId { get; set; }

        [Comment("Navigation property to the product that the image belongs to.")]
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Comment("The review id")]
        public int? ReviewId { get; set; }

        [Comment("Navigation property to the review that the image belongs to.")]
        [ForeignKey(nameof(ReviewId))]
        public Review? Review { get; set; }

        [Comment("The user id")]
        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

    }
}


