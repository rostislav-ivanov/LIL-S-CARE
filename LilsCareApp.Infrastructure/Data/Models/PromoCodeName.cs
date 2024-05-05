using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.PromoCode;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class PromoCodeName
    {
        [Comment("Promo code name id")]
        [Key]
        public int Id { get; set; }

        [Comment("The promo code name in English")]
        [MaxLength(NameMaxLength)]
        public required string NameEN { get; set; }

        [Comment("The promo code name in Bulgarian")]
        [MaxLength(NameMaxLength)]
        public required string NameBG { get; set; }

        [Comment("The promo code name in Romanian")]
        [MaxLength(NameMaxLength)]
        public required string NameRO { get; set; }

        public int PromoCodeId { get; set; }

        public PromoCode PromoCode { get; set; } = null!;
    }
}