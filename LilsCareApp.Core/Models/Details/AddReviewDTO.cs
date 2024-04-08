using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Review;

namespace LilsCareApp.Core.Models.Details
{
    public class AddReviewDTO
    {
        public int ProductId { get; set; }

        public required string ProductName { get; set; }

        public string? ProductImage { get; set; }

        public required string AuthorId { get; set; }


        public required string AuthorName { get; set; }

        public required string Email { get; set; }

        public string? Title { get; set; }

        public string? Comment { get; set; }

        public ImageDTO[] Images { get; set; } =
            {
                new ImageDTO() { ImagePath = string.Empty},
                new ImageDTO() { ImagePath = string.Empty},
                new ImageDTO() { ImagePath = string.Empty}
            };

        public bool[] Stars { get; set; } = { false, false, false, false, false };

        [Range(RatingMinValue, RatingMaxValue, ErrorMessage = RatingRange)]
        public int Rating { get; set; }
    }
}