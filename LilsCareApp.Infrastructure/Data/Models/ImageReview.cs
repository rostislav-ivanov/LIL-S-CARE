using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Image;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("The image of the review")]
    public class ImageReview
    {
        [Comment("The image id")]
        [Key]
        public int Id { get; set; }

        [Comment("The path of the image")]
        [Required]
        [MaxLength(ImagePathMaxLength)]
        public required string ImagePath { get; set; }


        [Comment("The identifier of the product.")]
        public int ProductId { get; set; }

        [Comment("The identifier of the author.")]
        public string? AuthorId { get; set; }

        [Comment("The review that this image belongs to.")]
        public Review Review { get; set; } = null!;

    }
}


