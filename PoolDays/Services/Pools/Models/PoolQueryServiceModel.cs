using PoolDays.Services.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services
{
    public class PoolQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int TotalPools { get; init; }

        public int PoolsPerPage { get; init; }

        public IEnumerable<PoolServiceModel> Pools { get; init; }
    }
}
