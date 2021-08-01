using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Api.Pools
{
    public class AllPoolsResponseApiModel
    {
        public int CurrentPage { get; set; }

        public int TotalPools { get; init; }

        public int PoolsPerPage { get; init; }

        public IEnumerable<PoolResponseModel> Pools { get; init; }
    }
}
