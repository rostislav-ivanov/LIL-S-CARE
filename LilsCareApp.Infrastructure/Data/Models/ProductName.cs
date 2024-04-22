using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LilsCareApp.Infrastructure.Data.Models
{
    public class ProductName
    {
        [Key]
        public int Id { get; set; }

        public required string NameEN { get; set; }

        public required string NameBG { get; set; }

        public required string NameRO { get; set; }

        [Comment("Navigation Property to Products")]
        public IEnumerable<Product> Products { get; set; } = [];

    }
}