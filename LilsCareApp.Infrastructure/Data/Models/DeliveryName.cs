using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.DeliveryMethod;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class DeliveryName
    {
        [Comment("The delivery name Id")]
        [Key]
        public int Id { get; set; }

        [Comment("The delivery name in English")]
        [MaxLength(NameMaxLength)]
        public required string NameEN { get; set; }

        [Comment("The delivery name in Bulgarian")]
        [MaxLength(NameMaxLength)]
        public required string NameBG { get; set; }

        [Comment("The delivery name in Romanian")]
        [MaxLength(NameMaxLength)]
        public required string NameRO { get; set; }

        [Comment("Navigation Property to DeliveryMethod")]
        public IEnumerable<DeliveryMethod> DeliveryMethod { get; set; } = [];
    }
}
