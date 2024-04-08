using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Section;

namespace LilsCareApp.Core.Models.Details
{
    public class SectionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLength)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLength)]
        public string Description { get; set; } = string.Empty;

        public int SectionOrder { get; set; }
    }
}