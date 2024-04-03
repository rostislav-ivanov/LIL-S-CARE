using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Product;

namespace LilsCareApp.Core.Models
{
    public class DetailsDTO
    {
        private const string separator = "\r\n";
        public int Id { get; set; }

        [Required(ErrorMessage = Required)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLength)]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public string Optional { get; set; } = string.Empty;

        public List<SectionDTO> Sections { get; set; } = [];

        public List<ImageDTO> Images { get; set; } = [];

        public List<GetReviewDTO> Reviews { get; set; } = [];

        public double Rating { get; set; }

        public List<CategoryDTO> ProductsCategories { get; set; } = [];

        public bool IsWish { get; set; }

        public AddReviewDTO? AddReview { get; set; }


        public List<string> GetSection(int sectionOrder)
        {
            var section = Sections
                .FirstOrDefault(s => s.SectionOrder == sectionOrder);
            return section != null ? section.Description.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToList() : [];
        }

    }
}
