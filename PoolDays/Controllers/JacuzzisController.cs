using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Infrastructure;
using PoolDays.Models.Comments;
using PoolDays.Models.Jacuzzies;
using PoolDays.Services.Comments;
using PoolDays.Services.Employees;
using PoolDays.Services.Jacuzzies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class JacuzzisController : Controller
    {
        private readonly IEmployeeService employee;
        private readonly IJacuzziService jacuzzis;
        private readonly IMapper mapper;
        private readonly ICommentService comments;

        public JacuzzisController(IEmployeeService employee, IJacuzziService jacuzzies, PoolDaysDBContext data, 
            IMapper mapper, ICommentService comments)
        {
            this.employee = employee;
            this.jacuzzis = jacuzzies;
            this.mapper = mapper;
            this.comments = comments;
        }

       
        public IActionResult All([FromQuery] AllJacuzziSearchQueryModel query)
        {
            var queryResult = this.jacuzzis.All(
                query.Manufacturer,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllJacuzziSearchQueryModel.JacuzziPerPage);

            var jacuzziManufacturers = this.jacuzzis.AllJacuzziManufacturers();

            query.TotalJacuzzi = queryResult.TotalJacuzzis;
            query.Manufacturers = jacuzziManufacturers;
            query.Jacuzzis = queryResult.Jacuzzis;

            return View(query);
        }

        public IActionResult Add()
        {
            if (!this.employee.UserIsEmployee(this.User.GetId()))
            {
                return RedirectToAction(nameof(UsersController.Create), "Employees");
            }

            return View(new JacuzziFormModel
            {
                Categories = this.jacuzzis.AllJacuzziCategories()
            });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0 && !User.isAdmin())
            {
                return RedirectToAction(nameof(UsersController.Create), "Employees");
            }

            var jacuzzi = this.jacuzzis.Details(id);

            if (jacuzzi.EmployeeId != employeeId && !User.isAdmin())
            {
                return Unauthorized();
            }

            var jacuzziForm = mapper.Map<JacuzziFormModel>(jacuzzi);
            jacuzziForm.Categories = this.jacuzzis.AllJacuzziCategories();

            return View(jacuzziForm);
        }

        public IActionResult Details(int id)
        {
            var jacuzzi = this.jacuzzis
                 .Details(id);

            var jacuzziDetails = this.mapper.Map<JacuzziFormModel>(jacuzzi);

            return View(jacuzziDetails);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(JacuzziFormModel jacuzzi)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0)
            {
                return RedirectToAction(nameof(UsersController.Create), "Employees");
            }

            if (!jacuzzis.CategoryExists(jacuzzi.CategoryId))
            {
                this.ModelState.AddModelError(nameof(jacuzzi.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                jacuzzi.Categories = this.jacuzzis.AllJacuzziCategories();

                return View(jacuzzi);
            }

            this.jacuzzis.Create(jacuzzi.Manufacturer, jacuzzi.Model, jacuzzi.Description, jacuzzi.Volume, jacuzzi.Height,
            jacuzzi.Length, jacuzzi.Width, jacuzzi.Price, jacuzzi.ImageUrl, jacuzzi.CategoryId, employeeId);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, JacuzziFormModel jacuzzi)
        {
            var employeeId = employee.EmployeeId(this.User.GetId());

            if (employeeId == 0 && !User.isAdmin())
            {
                return RedirectToAction(nameof(UsersController.Create), "Employees");
            }

            var isEdited = this.jacuzzis.Edit(id, jacuzzi.Manufacturer, jacuzzi.Model, jacuzzi.Description, 
                jacuzzi.Volume, jacuzzi.Length, jacuzzi.Height, jacuzzi.Width, jacuzzi.Price, jacuzzi.ImageUrl,
                jacuzzi.CategoryId, employeeId);

            if (!User.isAdmin())
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult AddComment()
        {
            return View(new CommentFormModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddComment(int id, CommentFormModel comment)
        {
            var userId = User.GetId();

            this.comments.Create(comment.Text, comment.ProductRankting, comment.PoolId, id, userId);

            return RedirectToAction(nameof(Details));
        }
    }
}
