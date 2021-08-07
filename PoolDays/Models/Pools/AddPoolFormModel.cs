using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static PoolDays.Data.DataConstants.Pool;

namespace PoolDays.Models.Pools
{
    public class AddPoolFormModel
    {
        [Required]
        [StringLength(
            PoolManufacturerMaxLength, 
            MinimumLength = PoolManufacturerMinLength, 
            ErrorMessage = "Values must be between {2} and {1} characters.")]       // TODO: For all other fields.. 
        public string Manufacturer { get; init; }

        [Required]
        [MinLength(PoolModelMinLength)]
        [MaxLength(PoolModelMaxLength)]
        public string Model { get; init; }

        [Required]
        [MinLength(PoolDescriptionMinLength)]
        [MaxLength(PoolDescriptionMaxLength)]
        public string Description { get; init; }

        [Range(PoolVolumeMinValue, PoolVolumeMaxValue)]
        public double Volume { get; init; }

        [Range(PoolHeightMinValue, PoolHeightMaxValue)]
        public double Height { get; init; }

        [Range(PoolLengthMinValue, PoolLengthMaxValue)]
        public double Length { get; init; }
        
        [Range(PoolWidthtMinValue, PoolWidthMaxValue)]
        public double Width { get; init; }

        public double? Diameter { get; init; }

        public bool PumpIncluded { get; init; }

        public bool Stairway { get; init; }

        [Required]
        [Display(Name = "Image URL")]
        [MinLength(ImageURLStringMinLength)]
        public string ImageUrl { get; init; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PoolCategoryServiceModel> Categories { get; set; }
    }
}
