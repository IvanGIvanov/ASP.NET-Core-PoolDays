using PoolDays.Models;
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
            Sorting sorting,
            int currentPage,
            int poolsPerPage);

        PoolServiceModel Details(int id);

        IEnumerable<string> AllPoolManufacturers();
    }
}
