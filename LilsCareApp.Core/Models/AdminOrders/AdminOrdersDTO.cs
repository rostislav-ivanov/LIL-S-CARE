namespace LilsCareApp.Core.Models.AdminOrders
{
    public class AdminOrdersDTO
    {
        public IEnumerable<AdminOrderDTO> Orders { get; set; } = [];

        public IEnumerable<StatusOrderDTO> StatusesOrder { get; set; } = [];

        public int TotalOrdersCount { get; set; }

        public int OrdersPerPage { get; set; }

        public int CurrentPage { get; set; }

        public string? Status { get; set; }

        public bool? Payment { get; set; }

        public OrderSortType OrderSortType { get; set; }

        public string? Search { get; set; }
    }
}
