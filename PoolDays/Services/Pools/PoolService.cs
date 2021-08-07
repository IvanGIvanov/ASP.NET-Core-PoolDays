using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Models;
using PoolDays.Models.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Pools
{
    public class PoolService : IPoolService
    {
        private readonly PoolDaysDBContext data;

        public PoolService(PoolDaysDBContext data) => this.data = data;


        public PoolQueryServiceModel All(
            string manufacturer, 
            string searchTerm, 
            Sorting sorting,
            int currentPage,
            int poolsPerPage)
        {
            var poolQueriable = this.data.Pools.AsQueryable();

            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                poolQueriable = poolQueriable
                    .Where(p => p.Manufacturer == manufacturer);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                poolQueriable = poolQueriable
                    .Where(p => p.Manufacturer.ToLower().Contains(searchTerm.ToLower())
                    || p.Model.ToLower().Contains(searchTerm.ToLower())
                    || p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            poolQueriable = sorting switch
            {
                Sorting.Manufacturer => poolQueriable.OrderBy(p => p.Manufacturer),
                Sorting.Volume => poolQueriable.OrderByDescending(p => p.Volume),
                Sorting.DateCreated or _ => poolQueriable.OrderByDescending(p => p.Id)
            };

            var totalPools = poolQueriable.Count();

            var pools = poolQueriable
                .Skip((currentPage - 1) * poolsPerPage)
                .Take(poolsPerPage)
                .Select(p => new PoolServiceModel
                {
                    Id = p.Id,
                    Manufacturer = p.Manufacturer,
                    Model = p.Model,
                    Description = p.Description,
                    Volume = p.Volume,
                    Height = p.Height,
                    Length = p.Length,
                    Width = p.Width,
                    PumpIncluded = p.PumpIncluded,
                    Stairway = p.Stairway,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name
                })
                .ToList();

            return new PoolQueryServiceModel
            {
                TotalPools = totalPools,
                CurrentPage = currentPage,
                PoolsPerPage = poolsPerPage,
                Pools = pools,
            };
        }

        public PoolServiceModel Details(int id)
            => this.data
            .Pools
            .Where(p => p.Id == id)
            .Select(p => new PoolServiceModel
            {
                Id = p.Id,
                Manufacturer = p.Manufacturer,
                Model = p.Model,
                Description = p.Description,
                Volume = p.Volume,
                Height = p.Height,
                Length = p.Length,
                Width = p.Width,
                PumpIncluded = p.PumpIncluded,
                Stairway = p.Stairway,
                ImageUrl = p.ImageUrl,
                Category = p.Category.Name
            })
            .FirstOrDefault();

        public IEnumerable<string> AllPoolManufacturers()
        {
            return this.data
                .Pools
                .Select(p => p.Manufacturer)
                .Distinct()
                .OrderBy(p => p)
                .ToList();
        }

        public IEnumerable<PoolCategoryServiceModel> AllPoolCategories()
            => this.data
                .Categories
                .Select(p => new PoolCategoryServiceModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();

        public bool CategoryExists(int categoryId)
            => this.data.Categories.Any(p => p.Id == categoryId);

        public int Create(string manufacturer, string model, string description, double volume, double length, 
            double height, double width, bool pumpIncluded, bool stairway, string imageUrl, int categoryId, 
            int? employeeId)
        {
            var poolData = new Pool
            {
                Manufacturer = manufacturer,
                Model = model,
                Description = description,
                Volume = volume,
                Length = length,
                Height = height,
                Width = width,
                PumpIncluded = pumpIncluded,
                Stairway = stairway,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                EmployeeId = employeeId,
            };

            this.data.Pools.Add(poolData);
            this.data.SaveChanges();

            return poolData.Id;
        }
    }
}
