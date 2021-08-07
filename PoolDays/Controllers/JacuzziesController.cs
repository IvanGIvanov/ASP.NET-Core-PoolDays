using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Infrastructure;
using PoolDays.Models.Jacuzzies;
using PoolDays.Services.Employees;
using PoolDays.Services.Jacuzzies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class JacuzziesController : Controller
    {
        private readonly IEmployeeService employee;
        private readonly IJacuzziService jacuzzies;
        private readonly PoolDaysDBContext data;

        public JacuzziesController(IEmployeeService employee, IJacuzziService jacuzzies, PoolDaysDBContext data) 
        {
            this.employee = employee;
            this.jacuzzies = jacuzzies;
            this.data = data;
        }

        public IActionResult Add()
        {
            if (!this.employee.UserIsEmployee(this.User.GetId()))
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            return View(new AddJacuzziFormModel
            {
                Categories = this.jacuzzies.AllJacuzziCategories()
            });
        }

        public IActionResult All([FromQuery] AllJacuzzieSearchQueryModel query)
        {
            var queryResult = this.jacuzzies.All(
                query.Manufacturer,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllJacuzzieSearchQueryModel.JacuzziPerPage);

            var jacuzzieManufacturers = this.jacuzzies.AllJacuzziManufacturers();

            query.TotalJacuzzi = queryResult.TotalJacuzzies;
            query.Manufacturers = jacuzzieManufacturers;
            query.Jacuzzies = queryResult.Jacuzzies;

            return View(query);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddJacuzziFormModel jacuzzi)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0)
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            if (!jacuzzies.CategoryExists(jacuzzi.CategoryId))
            {
                this.ModelState.AddModelError(nameof(jacuzzi.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                jacuzzi.Categories = this.jacuzzies.AllJacuzziCategories();

                return View(jacuzzi);
            }

            var jacuzziData = new Jacuzzi
            {
                Manufacturer = jacuzzi.Manufacturer,
                Model = jacuzzi.Model,
                Description = jacuzzi.Description,
                Volume = jacuzzi.Volume,
                Height = jacuzzi.Height,
                Length = jacuzzi.Length,
                Width = jacuzzi.Width,
                Price = jacuzzi.Price,
                ImageUrl = jacuzzi.ImageUrl,
                CategoryId = jacuzzi.CategoryId,
                EmployeeId = employeeId
            };

            this.data.Add(jacuzziData);
            this.data.SaveChanges();

            return View();
        }
    }
}
