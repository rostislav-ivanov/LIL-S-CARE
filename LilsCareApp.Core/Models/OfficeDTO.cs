using System.ComponentModel.DataAnnotations;

using static LilsCareApp.Core.ErrorMessageConstants;

namespace LilsCareApp.Core.Models
{
    public class OfficeDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = Required)]
        [Display(Name = "град")]

        public required string City { get; set; }


        [Required(ErrorMessage = Required)]
        [Display(Name = "офис")]

        public required string Address { get; set; }

        public decimal Price { get; set; }
    }
}