using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Pools
{
    public class AllPoolsSearchQueryModel
    {
        public IEnumerable<string> Manufacturers { get; set; }

        public IEnumerable<string> Model { get; set; }

        public PoolSorting Sorting { get; set; }

        public IEnumerable<PoolListViewModel> Pools { get; set; }
    }
}
