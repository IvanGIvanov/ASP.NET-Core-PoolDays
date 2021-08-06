using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Infrastructure;
using PoolDays.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly PoolDaysDBContext data;

        public EmployeesController(PoolDaysDBContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Create(BecomeEmployeeFormModel employee)
        {
            var userId = this.User.GetId();

            var userIsAlreadyEmployee = this.data
                .Employees
                .Any(e => e.UserId == userId);

            if (userIsAlreadyEmployee)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var employeeModel = new Employee
            {
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                UserId = userId
            };

            this.data.Employees.Add(employeeModel);
            this.data.SaveChanges();

            return RedirectToAction(nameof(PoolsController.All), "Pools");
        }
    }
}
