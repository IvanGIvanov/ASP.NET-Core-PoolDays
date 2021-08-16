using PoolDays.Services.Comments;
using PoolDays.Services.Comments.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static PoolDays.Data.DataConstants.Pool;

namespace PoolDays.Models.Pools
{
    public class PoolFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            PoolManufacturerMaxLength, 
            MinimumLength = PoolManufacturerMinLength, 
            ErrorMessage = "Values must be between {2} and {1} characters.")]
        public string Manufacturer { get; init; }

        [Required]
        [StringLength(
            PoolModelMaxLength,
            MinimumLength = PoolModelMinLength,
            ErrorMessage = "Values must be between {2} and {1} characters.")]
        public string Model { get; init; }

        [Required]
        [StringLength(
            PoolDescriptionMaxLength,
            MinimumLength = PoolDescriptionMinLength,
            ErrorMessage = "Values must be between {2} and {1} characters.")]
        public string Description { get; init; }

        [Range(PoolVolumeMinValue, PoolVolumeMaxValue)]
        public double Volume { get; init; }

        [Range(PoolHeightMinValue, PoolHeightMaxValue)]
        public double Height { get; init; }

        [Range(PoolLengthMinValue, PoolLengthMaxValue)]
        public double Length { get; init; }
        
        [Range(PoolWidthtMinValue, PoolWidthMaxValue)]
        public double Width { get; init; }

        public decimal Price { get; set; }

        public double? Diameter { get; init; }

        public bool PumpIncluded { get; init; }

        public bool Stairway { get; init; }

        [Required]
        [Url]
        [Display(Name = "Image URL:")]
        [MinLength(ImageURLStringMinLength, ErrorMessage = "Enter valid URL")]
        public string ImageUrl { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PoolCategoryServiceModel> Categories { get; set; }

        public IEnumerable<CommentShowModel> Comments { get; set; }
    }
}
