using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Pools
{
    public class PoolServiceModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public double Volume { get; set; }

        public double Length { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public decimal Price { get; set; }

        public bool PumpIncluded { get; set; }

        public bool Stairway { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; } 

        public string EmployeeId { get; set; }
    }
}
