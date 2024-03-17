namespace LilsCareApp.Core.Models
{
    public class DeliveryTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public bool IsDeliveryToAddress { get; set; }

    }
}