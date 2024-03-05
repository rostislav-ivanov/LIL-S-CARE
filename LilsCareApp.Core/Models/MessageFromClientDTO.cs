namespace LilsCareApp.Core.Models
{
    public class MessageFromClientDTO
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }

        public required string EmailForResponse { get; set; }

        public required string Message { get; set; }

        public string? AppUserId { get; set; }
    }
}
