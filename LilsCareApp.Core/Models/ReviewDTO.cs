using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Core.Models
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public required string AuthorName { get; set; }
        public required string Email { get; set; }
        public int Rating { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public List<Image>? Images { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductId { get; set; }
        public string? AuthorId { get; set; }
    }
}