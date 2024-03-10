namespace LilsCareApp.Core.Models
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

        public List<string> Images { get; set; } = new List<string>();

        public bool[] Stars { get; set; } = { false, false, false, false, false, false };
    }
}