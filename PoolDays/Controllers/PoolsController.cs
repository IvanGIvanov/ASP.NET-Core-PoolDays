using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Infrastructure;
using PoolDays.Models.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class PoolsController : Controller
    {
        private readonly PoolDaysDBContext data;

        public PoolsController(PoolDaysDBContext data) 
            => this.data = data;

        [Authorize]
        public IActionResult Add()
        {
            if (!this.UserIsEmployee())
            {               
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            return View(new AddPoolFormModel
            {
                Categories = this.GetPoolCategories()

            });
        }

        public IActionResult All()
        {
            var pools = this.data
                .Pools
                .OrderByDescending(p => p.Id)
                .Select(p => new PoolListViewModel
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

            return View(new AllPoolsSearchQueryModel
            {
                Pools = pools,
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPoolFormModel pool)
        {
            var employeeId = this.data
                .Employees
                .Where(e => e.UserId == this.User.GetId())
                .Select(e => e.Id)
                .FirstOrDefault();

            if (employeeId == 0)
            {
                return RedirectToAction(nameof(EmployeesController.Create), "Employees");
            }

            if (!this.data.Categories.Any(p => p.Id == pool.CategoryId))
            {
                this.ModelState.AddModelError(nameof(pool.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                pool.Categories = this.GetPoolCategories();

                return View(pool);
            }

            var poolData = new Pool
            {
                Manufacturer = pool.Manufacturer,
                Model = pool.Model,
                Description = pool.Description,
                Volume = pool.Volume,
                Length = pool.Length,
                Height = pool.Height,
                Width = pool.Width,
                PumpIncluded = pool.PumpIncluded,
                Stairway = pool.Stairway,
                ImageUrl = pool.ImageUrl,
                CategoryId = pool.CategoryId,
                EmployeeId = employeeId,
            };

            this.data.Pools.Add(poolData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private bool UserIsEmployee()
            => this.data
                .Employees
                .Any(e => e.UserId == this.User.GetId());

        private IEnumerable<PoolCategoryViewModel> GetPoolCategories()
            => this.data
                .Categories
                .Select(p => new PoolCategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();
    }
}
