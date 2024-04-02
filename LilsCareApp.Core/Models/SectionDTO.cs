namespace LilsCareApp.Core.Models
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int SectionOrder { get; set; }
    }
}