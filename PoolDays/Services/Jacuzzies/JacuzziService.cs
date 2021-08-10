using AutoMapper;
using AutoMapper.QueryableExtensions;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Models;
using PoolDays.Models.Jacuzzies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Jacuzzies
{
    public class JacuzziService : IJacuzziService
    {
        private readonly PoolDaysDBContext data;
        private readonly IMapper mapper;

        public JacuzziService(PoolDaysDBContext data, IMapper mapper) 
        {
            this.data = data;
            this.mapper = mapper;
        }


        public JacuzziQueryServiceModel All(
            string manufacturer,
            string searchTerm,
            Sorting sorting,
            int currentPage,
            int jaccuziPerPage)
        {
            var jacuzzieQueriable = this.data.Jacuzzies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                jacuzzieQueriable = jacuzzieQueriable
                    .Where(p => p.Manufacturer == manufacturer);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                jacuzzieQueriable = jacuzzieQueriable
                    .Where(p => p.Manufacturer.ToLower().Contains(searchTerm.ToLower())
                    || p.Model.ToLower().Contains(searchTerm.ToLower())
                    || p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            jacuzzieQueriable = sorting switch
            {
                Sorting.Manufacturer => jacuzzieQueriable.OrderBy(p => p.Manufacturer),
                Sorting.Volume => jacuzzieQueriable.OrderByDescending(p => p.Volume),
                Sorting.DateCreated or _ => jacuzzieQueriable.OrderByDescending(p => p.Id)
            };

            var totalJacuzzies = jacuzzieQueriable.Count();

            var jacuzzies = jacuzzieQueriable
                .Skip((currentPage - 1) * jaccuziPerPage)
                .Take(jaccuziPerPage)
                .ProjectTo<JacuzziServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return new JacuzziQueryServiceModel
            {
                TotalJacuzzies = totalJacuzzies,
                CurrentPage = currentPage,
                JacuzziPerPage = jaccuziPerPage,
                Jacuzzies = jacuzzies,
            };
        }

        public IEnumerable<string> AllJacuzziManufacturers()
        {
            return this.data
                .Jacuzzies
                .Select(p => p.Manufacturer)
                .Distinct()
                .OrderBy(p => p)
                .ToList();
        }

        public IEnumerable<JacuzziCategoryServiceModel> AllJacuzziCategories()
            => this.data
                .Categories
                .Where(c => c.Type == 2)
                .Select(j => new JacuzziCategoryServiceModel
                {
                    Id = j.Id,
                    Name = j.Name,
                })
                .ToList();

        public bool CategoryExists(int categoryId)
            => this.data.Categories.Any(p => p.Id == categoryId);

        public int Create(string manufacturer, string model, string description, double volume, double height, 
            double length, double width, decimal price, string imageUrl, int categoryId, int employeeId)
        {
            var jacuzziData = new Jacuzzi
            {
                Manufacturer = manufacturer,
                Model = model,
                Description = description,
                Volume = volume,
                Height = height,
                Length = length,
                Width = width,
                Price = price,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                EmployeeId = employeeId,
            };

            this.data.Add(jacuzziData);
            this.data.SaveChanges();

            return jacuzziData.Id;
        }

        public bool Edit(int id, string manufacturer, string model, string description, double volume, 
            double length, double height, double width, decimal price, string imageUrl, 
            int categoryId, int employeeId)
        {
            var jacuzziData = this.data.Jacuzzies.Find(id);

            jacuzziData.Manufacturer = manufacturer;
            jacuzziData.Model = model;
            jacuzziData.Description = description;
            jacuzziData.Volume = volume;
            jacuzziData.Length = length;
            jacuzziData.Height = height;
            jacuzziData.Width = width;
            jacuzziData.Price = price;
            jacuzziData.ImageUrl = imageUrl;
            jacuzziData.CategoryId = categoryId;

            this.data.SaveChanges();

            return true;
        }

        public JacuzziServiceModel Details(int id)
          => this.data
            .Jacuzzies
            .Where(j => j.Id == id)
            .ProjectTo<JacuzziServiceModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();
        
    }
}
