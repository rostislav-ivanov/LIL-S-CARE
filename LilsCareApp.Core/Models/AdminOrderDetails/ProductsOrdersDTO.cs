namespace LilsCareApp.Core.Models.AdminOrderDetails
{
    public class ProductsOrdersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;

        public string Optional { get; set; } = string.Empty;


    }
}