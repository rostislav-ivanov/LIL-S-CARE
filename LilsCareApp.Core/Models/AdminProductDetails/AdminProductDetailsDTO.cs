using LilsCareApp.Core.Models.Details;
using LilsCareApp.Core.Models.Products;
using LilsCareApp.Infrastructure;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Product;
using static LilsCareApp.Infrastructure.DataConstants.Section;


namespace LilsCareApp.Core.Models.AdminProductDetails
{
    public class AdminProductDetailsDTO
    {
        public Language Language { get; set; }

        public IEnumerable<Language> Languages { get; set; } = [];

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLength)]
        [Display(Name = "име на продукт")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Range(minimum: 0.00, maximum: 1000.00, ConvertValueInInvariantCulture = true, ErrorMessage = ProductPriceRange)]
        [Display(Name = "цена")]
        public decimal Price { get; set; }

        [Range(minimum: QuantityMinValue, maximum: QuantityMaxValue, ErrorMessage = QuantityRange)]
        [Display(Name = "количество")]
        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        [StringLength(OptionalMaxLength, MinimumLength = OptionalMinLength, ErrorMessage = StringLength)]
        [Display(Name = "допълнителна информация")]
        public string Optional { get; set; } = string.Empty;

        public List<SectionDTO> Sections { get; set; } = [];

        public List<ImageDTO> Images { get; set; } = [];

        public List<CategoryDTO> ProductsCategories { get; set; } = [];

        public IEnumerable<CategoryDTO> Categories { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLength)]
        [Display(Name = "име на секцията")]
        public string SectionTitle { get; set; } = string.Empty;

        [StringLength(DataConstants.Category.NameMaxLength, MinimumLength = DataConstants.Category.NameMinLength, ErrorMessage = StringLength)]
        [Display(Name = "категория")]
        public string NewCategory { get; set; } = string.Empty;
    }
}
