using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PoolDays.Data.Models
{
    using static PoolDays.Data.DataConstants.Pool;

    public class Pool
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(PoolManufacturerMaxLength)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(PoolModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(PoolDescriptionMaxLength)]
        public string Description { get; set; }

        [Range(1, 199)]
        public double Volume { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double? Diameter { get; set; }

        public decimal Price { get; set; }

        public bool PumpIncluded { get; set; }

        public bool Stairway { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string EmployeeId { get; set; }

        public User Employee { get; init; }

        public int CommentId { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}
