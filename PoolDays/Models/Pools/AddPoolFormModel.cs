using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Pools
{
    public class AddPoolFormModel
    {
        public string Manufacturer { get; init; }

        public string Model { get; init; }

        public string Description { get; init; }

        public double Volume { get; init; }

        public double Height { get; init; }

        public double Width { get; init; }

        public double Depth { get; init; }

        public double? Diameter { get; init; }

        public bool PumpIncluded { get; init; }

        public bool Stairway { get; init; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PoolCategoryViewModel> Categories { get; set; }
    }
}
