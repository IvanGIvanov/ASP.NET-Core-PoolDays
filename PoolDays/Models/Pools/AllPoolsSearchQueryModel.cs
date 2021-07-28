using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Pools
{
    public class AllPoolsSearchQueryModel
    {
        public string Manufacturer { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        [Display(Name = "Search Term")]
        public string SearchTerm { get; set; }

        public PoolSorting Sorting { get; set; }

        public IEnumerable<PoolListViewModel> Pools { get; set; }
    }
}
