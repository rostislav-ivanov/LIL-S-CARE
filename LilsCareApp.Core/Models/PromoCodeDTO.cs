namespace LilsCareApp.Core.Models
{
    public class PromoCodeDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
    }
}