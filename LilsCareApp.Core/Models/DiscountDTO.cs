namespace LilsCareApp.Core.Models
{
    public class DiscountDTO
    {
        public int Id { get; set; }

        public decimal Discount { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}