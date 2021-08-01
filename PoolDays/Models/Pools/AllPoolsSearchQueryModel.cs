using PoolDays.Services.Pools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Pools
{
    public class AllPoolsSearchQueryModel
    {
        public const int PoolsPerPage = 3; 

        public string Manufacturer { get; set; }

        public IEnumerable<string> Manufacturers { get; set; }

        [Display(Name = "Search Term:")]
        public string SearchTerm { get; set; }

        [Display(Name = "Sort by:")]
        public PoolSorting Sorting { get; init; }

        public int CurrentPage { get; set; } = 1;

        public int TotalPools { get; set; }

        public IEnumerable<PoolServiceModel> Pools { get; set; }
    }
}
