using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Infrastructure;
using PoolDays.Models;
using PoolDays.Models.Pools;
using PoolDays.Services.Employees;
using PoolDays.Services.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class PoolsController : Controller
    {
        private readonly IEmployeeService employee;
        private readonly IPoolService pools;

        public PoolsController(IEmployeeService employee, IPoolService pools)
        {
            this.employee = employee;
            this.pools = pools;
        }
            

        [Authorize]
        public IActionResult Add()
        {
            if (!this.employee.UserIsEmployee(this.User.GetId()))
            {               
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            return View(new PoolFormModel
            {
                Categories = this.pools.AllPoolCategories()
            });
        }

        public IActionResult All([FromQuery]AllPoolsSearchQueryModel query)
        {
            var queryResult = this.pools.All(
                query.Manufacturer,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllPoolsSearchQueryModel.PoolsPerPage);

            var poolManufacturers = this.pools.AllPoolManufacturers();
            
            query.TotalPools = queryResult.TotalPools;
            query.Manufacturers = poolManufacturers;
            query.Pools = queryResult.Pools;

            return View(query);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(PoolFormModel pool)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0)
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            if (!pools.CategoryExists(pool.CategoryId))
            {
                this.ModelState.AddModelError(nameof(pool.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                pool.Categories = this.pools.AllPoolCategories();

                return View(pool);
            }

            this.pools.Create(pool.Manufacturer, pool.Model, pool.Description, pool.Volume, pool.Length, pool.Height,
                pool.Width, pool.PumpIncluded, pool.Stairway, pool.ImageUrl, pool.CategoryId, employeeId);

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

            var pool = this.pools.Details(id);

            if (pool.EmployeeId != employeeId && !User.isAdmin())
            {
                return Unauthorized();
            }

            return View(new PoolFormModel
            {
                Manufacturer = pool.Manufacturer,
                Model = pool.Model,
                Description = pool.Description,
                Volume = pool.Volume,
                Height = pool.Height,
                Length = pool.Length,
                Width = pool.Width,
                PumpIncluded = pool.PumpIncluded,
                Stairway = pool.Stairway,
                ImageUrl = pool.ImageUrl,
                CategoryId = pool.CategoryId,
                Categories = this.pools.AllPoolCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, PoolFormModel pool)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0 && !User.isAdmin())
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            var isEdited = this.pools.Edit(id, pool.Manufacturer, pool.Model, pool.Description, pool.Volume, pool.Length, pool.Height,
                pool.Width, pool.PumpIncluded, pool.Stairway, pool.ImageUrl, pool.CategoryId, employeeId);

            if (!isEdited && !User.isAdmin())
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
