using PoolDays.Services.Comments.Model;
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
        public int Id { get; set; }

        [Required]
        [StringLength(
            JacuzziManufacturerMaxLength,
            MinimumLength = JacuzziManufacturerMinLength,
            ErrorMessage = "Values must be between {2} and {1} characters.")]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(
            JacuzziModelMaxLength,
            MinimumLength = JacuzziModelMinLength,
            ErrorMessage = "Values must be between {2} and {1} characters.")]
        public string Model { get; set; }

        [Required]
        [StringLength(
            JacuzziDescriptionMaxLength,
            MinimumLength = JacuzziDescriptionMinLength,
            ErrorMessage = "Values must be between {2} and {1} characters.")]
        public string Description { get; set; }

        [Range(JacuzziVolumeMinValue, JacuzziVolumeMaxValue)]
        public double Volume { get; set; }

        [Range(JacuzziHeightMinValue, JacuzziHeightMaxValue)]
        public double Height { get; set; }

        [Range(JacuzziLengthMinValue, JacuzziLengthMaxValue)]
        public double Length { get; set; }

        [Range(JacuzziWidthtMinValue, JacuzziWidthMaxValue)]
        public double Width { get; set; }

        [Range(JacuzziPriceMinValue, JacuzziPriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        [MinLength(ImageURLStringMinLength, ErrorMessage = "Enter valid URL")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<JacuzziCategoryServiceModel> Categories { get; set; }

        public IEnumerable<CommentShowModel> Comments { get; set; }
    }
}
