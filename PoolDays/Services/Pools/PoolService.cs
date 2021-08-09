using AutoMapper;
using AutoMapper.QueryableExtensions;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Models;
using PoolDays.Models.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PoolDays.Infrastructure.ClaimsPrincipalExtensions;

namespace PoolDays.Services.Pools
{
    public class PoolService : IPoolService
    {
        private readonly PoolDaysDBContext data;
        private readonly IMapper mapper;

        public PoolService(PoolDaysDBContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }


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
                .ProjectTo<PoolServiceModel>(this.mapper.ConfigurationProvider)
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
            .ProjectTo<PoolServiceModel>(this.mapper.ConfigurationProvider)
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
            int employeeId)
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

        public bool Edit(int id, string manufacturer, string model, string description, double volume, double length, 
            double height, double width, bool pumpIncluded, bool stairway, string imageUrl, int categoryId, 
            int employeeId)
        {
            var poolData = this.data.Pools.Find(id);

            poolData.Manufacturer = manufacturer;
            poolData.Model = model;
            poolData.Description = description;
            poolData.Volume = volume;
            poolData.Length = length;
            poolData.Height = height;
            poolData.Width = width;
            poolData.PumpIncluded = pumpIncluded;
            poolData.Stairway = stairway;
            poolData.ImageUrl = imageUrl;
            poolData.CategoryId = categoryId;

            this.data.SaveChanges();

            return true;
        }
    }
}
