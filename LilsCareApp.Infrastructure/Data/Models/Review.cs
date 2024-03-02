using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Review;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("This class represents a review of a product.")]
    public class Review
    {
        [Comment("The unique identifier of the review.")]
        [Key]
        public int Id { get; set; }

        [Comment("The name of the author of the review.")]
        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public required string AuthorName { get; set; }

        [Comment("The email of the author of the review.")]
        [Required]
        [MaxLength(EmailMaxLength)]
        public required string Email { get; set; }

        [Comment("The rating of the review.")]
        public int Rating { get; set; }

        [Comment("The title of the review.")]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        [Comment("The comment of the review.")]
        [MaxLength(CommentMaxLength)]
        public string? Comment { get; set; }

        [Comment("The images of the review.")]
        public List<Image>? Images { get; set; }

        [Comment("The date when the review was created.")]
        public DateTime CreatedOn { get; set; }

        [Comment("The identifier of the product.")]
        public int ProductId { get; set; }

        [Comment("The product that the review is for.")]
        public Product Product { get; set; } = null!;

        [Comment("If the creator of review is Login. The identifier of the user that created the review.")]
        public string? AppUserId { get; set; }

        [Comment("The user that created the review.")]
        public AppUser? AppUser { get; set; }
    }
}
