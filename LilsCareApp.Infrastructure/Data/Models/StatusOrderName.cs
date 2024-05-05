using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.StatusOrder;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class StatusOrderName
    {
        [Comment("Status order name id")]
        [Key]
        public int Id { get; set; }

        [Comment("The status order name in English")]
        [MaxLength(NameMaxLength)]
        public required string NameEN { get; set; }

        [Comment("The status order name in Bulgarian")]
        [MaxLength(NameMaxLength)]
        public required string NameBG { get; set; }

        [Comment("The status order name in Romanian")]
        [MaxLength(NameMaxLength)]
        public required string NameRO { get; set; }

        public int StatusOrderId { get; set; }

        public StatusOrder StatusOrder { get; set; } = null!;
    }
}