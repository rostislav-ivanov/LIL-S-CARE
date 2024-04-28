using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Status of the order")]
    public class StatusOrder
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the status Id")]
        public int NameId { get; set; }

        [ForeignKey(nameof(NameId))]
        public StatusOrderName Name { get; set; } = null!;


        [Comment("Navigation property to the orders")]
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}


