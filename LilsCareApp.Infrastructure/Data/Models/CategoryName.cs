using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Infrastructure.DataConstants.Category;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class CategoryName
    {
        [Key]
        public int Id { get; set; }

        [Comment("The category's name in English")]
        [MaxLength(NameMaxLength)]
        public required string NameEN { get; set; }

        [Comment("The category's name in Bulgarian")]
        [MaxLength(NameMaxLength)]
        public required string NameBG { get; set; }

        [Comment("The category's name in Romanian")]
        [MaxLength(NameMaxLength)]
        public required string NameRO { get; set; }
    }
}

