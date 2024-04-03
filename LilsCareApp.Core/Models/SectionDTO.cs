using System.ComponentModel.DataAnnotations;
using static LilsCareApp.Core.ErrorMessageConstants;
using static LilsCareApp.Infrastructure.DataConstants.Section;

namespace LilsCareApp.Core.Models
{
    public class SectionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Required)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLength)]
        public required string Title { get; set; }

        [Required(ErrorMessage = Required)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLength)]
        public required string Description { get; set; }

        public int SectionOrder { get; set; }
    }
}