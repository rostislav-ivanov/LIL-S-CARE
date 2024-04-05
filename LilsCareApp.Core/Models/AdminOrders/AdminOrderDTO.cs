using LilsCareApp.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilsCareApp.Core.Models.AdminOrders
{
    public class AdminOrderDTO
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Customer { get; set; } = string.Empty;

        public string Payment { get; set; } = string.Empty;

        public string StatusOrder { get; set; } = string.Empty;

        public decimal Total { get; set; }
    }
}
