using PoolDays.Data.Models;
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

        public int Create(string manufacturer, string model, string description, double volume, double length,
            double height, double width, bool pumpIncluded, bool stairway, string imageUrl, int categoryId,
            string employeeId, decimal price);

        public bool Edit(int id, string manufacturer, string model, string description, double volume, double length,
            double height, double width, bool pumpIncluded, bool stairway, string imageUrl, int categoryId,
            string employeeId);

        PoolServiceModel Details(int id);

        IEnumerable<string> AllPoolManufacturers();

        IEnumerable<PoolCategoryServiceModel> AllPoolCategories();

        public bool CategoryExists(int categoryId);
    }
}
