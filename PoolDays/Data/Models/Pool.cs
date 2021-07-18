using System.ComponentModel.DataAnnotations;


namespace PoolDays.Data.Models
{
    using static PoolDays.Data.DataConstants;

    public class Pool
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DataConstants.PoolManufacturerMaxLength)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(DataConstants.PoolModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DataConstants.PoolDescriptionMaxLength)]
        public string Description { get; set; }

        [Range(1, 199)]
        public double Volume { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double? Diameter { get; set; }

        public bool PumpIncluded { get; set; }

        public bool Stairway { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
