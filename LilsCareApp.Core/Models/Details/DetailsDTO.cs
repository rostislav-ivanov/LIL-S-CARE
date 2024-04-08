using LilsCareApp.Core.Models.Products;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Product;

namespace LilsCareApp.Core.Models.Details
{
    public class DetailsDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLength)]
        [Display(Name = "име на продукт")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Range(type: typeof(decimal),
            minimum: PriceMinValue,
            maximum: PriceMaxValue,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = ProductPriceRange)]
        [Display(Name = "цена")]
        public decimal Price { get; set; }

        [Range(type: typeof(int),
            minimum: QuantityMinValue,
            maximum: QuantityMaxValue,
            ErrorMessage = QuantityRange)]
        [Display(Name = "количество")]
        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        [StringLength(OptionalMaxLength, MinimumLength = OptionalMinLength, ErrorMessage = StringLength)]
        [Display(Name = "допълнителна информация")]
        public string Optional { get; set; } = string.Empty;

        public List<SectionDTO> Sections { get; set; } = [];

        public List<ImageDTO> Images { get; set; } = [];

        public List<GetReviewDTO> Reviews { get; set; } = [];

        public double Rating { get; set; }

        public List<CategoryDTO> ProductsCategories { get; set; } = [];

        public bool IsWish { get; set; }

        public AddReviewDTO? AddReview { get; set; }


        // Get the description of a section by its order number
        // Split the description by the separator new line.
        // Return the list of paragraphs.
        public List<string> GetSection(int sectionOrder)
        {
            var section = Sections
                .FirstOrDefault(s => s.SectionOrder == sectionOrder);
            if (string.IsNullOrEmpty(section?.Description))
            {
                return [];
            }
            return section.Description.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

    }
}
