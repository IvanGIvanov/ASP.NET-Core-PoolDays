using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data.Models
{
    public class Category
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public IEnumerable<Pool> Pools { get; set; } = new List<Pool>();
    }
}
