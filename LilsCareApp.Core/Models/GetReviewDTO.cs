namespace LilsCareApp.Core.Models
{
    public class GetReviewDTO
    {
        public int ProductId { get; set; }

        public required string AuthorName { get; set; }

        public int Rating { get; set; }

        public string? Title { get; set; }

        public string? Comment { get; set; }

        public List<ImageDTO>? Images { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}