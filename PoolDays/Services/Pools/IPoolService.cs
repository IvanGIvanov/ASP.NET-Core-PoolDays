using PoolDays.Models.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Pools
{
    public interface IPoolService
    {
        PoolQueryServiceModel All(
            string manufacturer,
            string searchTerm,
            PoolSorting sorting,
            int currentPage,
            int poolsPerPage);

        IEnumerable<string> AllPoolManufacturers();
    }
}
