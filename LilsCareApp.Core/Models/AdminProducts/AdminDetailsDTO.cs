using LilsCareApp.Core.Models.Details;
using LilsCareApp.Core.Models.Products;
using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Category;
using static LilsCareApp.Infrastructure.DataConstants.Section;

namespace LilsCareApp.Core.Models.AdminProducts
{
    public class AdminDetailsDTO : DetailsDTO
    {
        public IEnumerable<CategoryDTO> Categories { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLength)]
        [Display(Name = "име на секцията")]
        public string SectionTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLength)]
        [Display(Name = "описание на продукт")]
        public string SectionDescription { get; set; } = string.Empty;

        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLength)]
        [Display(Name = "категория")]
        public string NewCategory { get; set; } = string.Empty;


        // Get the list of categories' ids of the selected product
        public IEnumerable<int> GetProductCategoriesId() => ProductsCategories.Select(x => x.Id);
    }
}
