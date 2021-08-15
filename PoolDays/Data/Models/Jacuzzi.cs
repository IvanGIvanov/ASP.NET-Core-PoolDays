using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data.Models
{
    using static PoolDays.Data.DataConstants.Jacuzzi;
    public class Jacuzzi
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(JacuzziManufacturerMaxLength)]
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
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string EmployeeId { get; init; }

        public User Employee { get; init; }

        public int CommentId { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
