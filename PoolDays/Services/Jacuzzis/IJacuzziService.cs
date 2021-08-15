using PoolDays.Models;
using PoolDays.Models.Jacuzzies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Jacuzzies
{
    public interface IJacuzziService
    {
        JacuzziQueryServiceModel All(
            string manufacturer,
            string searchTerm,
            Sorting sorting,
            int currentPage,
            int jacuzziPerPage);

        int Create(string manufacturer, string model, string description, double volume, double height, double length,
                   double width, decimal price, string imageUrl, int categoryId, string employeeId);

        bool Edit(int id, string manufacturer, string model, string description, double volume, double length,
            double height, double width, decimal Price, string imageUrl, int categoryId,
            string employeeId);

        JacuzziServiceModel Details(int id);

        IEnumerable<string> AllJacuzziManufacturers();

        IEnumerable<JacuzziCategoryServiceModel> AllJacuzziCategories();

        public bool CategoryExists(int categoryId);
    }
}

