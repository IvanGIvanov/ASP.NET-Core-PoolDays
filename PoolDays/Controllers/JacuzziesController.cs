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

        public JacuzziesController(IEmployeeService employee, IJacuzziService jacuzzies, PoolDaysDBContext data) 
        {
            this.employee = employee;
            this.jacuzzies = jacuzzies;
        }

        public IActionResult Add()
        {
            if (!this.employee.UserIsEmployee(this.User.GetId()))
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            return View(new JacuzziFormModel
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
        public IActionResult Add(JacuzziFormModel jacuzzi)
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

            this.jacuzzies.Create(jacuzzi.Manufacturer, jacuzzi.Model, jacuzzi.Description, jacuzzi.Volume, jacuzzi.Height,
            jacuzzi.Length, jacuzzi.Width, jacuzzi.Price, jacuzzi.ImageUrl, jacuzzi.CategoryId, employeeId);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0 && !User.isAdmin())
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            var jacuzzi = this.jacuzzies.Details(id);

            if (jacuzzi.EmployeeId != employeeId && !User.isAdmin())
            {
                return Unauthorized();
            }

            return View(new JacuzziFormModel
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
                Categories = this.jacuzzies.AllJacuzziCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, JacuzziFormModel jacuzzi)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0 && !User.isAdmin())
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            var isEdited = this.jacuzzies.Edit(id, jacuzzi.Manufacturer, jacuzzi.Model, jacuzzi.Description, 
                jacuzzi.Volume, jacuzzi.Length, jacuzzi.Height, jacuzzi.Width, jacuzzi.Price, jacuzzi.ImageUrl,
                jacuzzi.CategoryId, employeeId);

            if (!isEdited && !User.isAdmin())
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
