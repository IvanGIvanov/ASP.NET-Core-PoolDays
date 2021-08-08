using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Jacuzzies
{
    using static Data.DataConstants.Jacuzzi;

    public class JacuzziFormModel
    {    
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(JacuzziModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(JacuzziDescriptionMaxLength)]
        public string Description { get; set; }

        [Range(1, 199)]
        public double Volume { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [MinLength(ImageURLStringMinLength)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<JacuzziCategoryServiceModel> Categories { get; set; }
    }
}
