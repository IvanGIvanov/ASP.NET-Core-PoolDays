using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data.Models
{
    public class Category
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        public int Type { get; set; }

        public IEnumerable<Pool> Pools { get; set; } = new List<Pool>();
    }
}
