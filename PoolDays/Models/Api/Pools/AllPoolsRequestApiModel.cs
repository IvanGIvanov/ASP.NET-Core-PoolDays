using PoolDays.Models.Pools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Api.Pools
{
    public class AllPoolsRequestApiModel
    {
        public string Manufacturer { get; set; }

        public string SearchTerm { get; set; }

        public Sorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int PoolsPerPage { get; init; } = 9;
    }
}
