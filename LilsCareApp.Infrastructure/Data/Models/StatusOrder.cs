using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.StatusOrder;

namespace LilsCareApp.Infrastructure.Data.Models
{
    [Comment("Status of the order")]
    public class StatusOrder
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the status")]
        [Required]
        [MaxLength(NameMaxLength)]
        public required string Name { get; set; }

        [Comment("Navigation property to the orders")]
        public List<Order> Orders { get; set; } = new List<Order>();


    }
}


