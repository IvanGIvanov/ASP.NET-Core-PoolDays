using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Infrastructure;
using PoolDays.Models.Comments;
using PoolDays.Models.Pools;
using PoolDays.Services.Comments;
using PoolDays.Services.Pools;

namespace PoolDays.Controllers

{
    using static WebConstants;

    public class PoolsController : Controller
    {
        private readonly IPoolService pools;
        private readonly IMapper mapper;
        private readonly ICommentService comments;

        public PoolsController(IPoolService pools, IMapper mapper, ICommentService comments)
        {
            this.pools = pools;
            this.mapper = mapper;
            this.comments = comments;
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

        [Authorize]
        public IActionResult Add()
        {
            if (!User.IsInRole(AdministatorRoleName) && !User.IsInRole(EmployeeRoleName))
            {
                return Unauthorized();
            }

            return View(new PoolFormModel
            {
                Categories = this.pools.AllPoolCategories()
            });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {

            if (!User.IsInRole(AdministatorRoleName) && !User.IsInRole(EmployeeRoleName))
            {
                return Unauthorized();
            }

            var pool = this.pools.Details(id);

            if (!User.IsInRole(AdministatorRoleName) && !User.IsInRole(EmployeeRoleName))
            {
                return Unauthorized();
            }

            var poolForm = this.mapper.Map<PoolFormModel>(pool);
            poolForm.Categories = this.pools.AllPoolCategories();

            return View(poolForm);
        }

        
        public IActionResult Details(int id)
        {
            var pool = this.pools
                 .Details(id);

            var showComments = this.comments.ShowPoolComment(id);

            var poolDetails = this.mapper.Map<PoolFormModel>(pool);
            poolDetails.Comments = showComments;

            return View(poolDetails);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(PoolFormModel pool)
        {
            var employeeId = this.User.GetId();

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

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, PoolFormModel pool)
        {
            var employeeId = this.User.GetId();

            if (!User.IsInRole(AdministatorRoleName) && !User.IsInRole(EmployeeRoleName))
            {
                return Unauthorized();
            }

            var isEdited = this.pools.Edit(id, pool.Manufacturer, pool.Model, pool.Description, pool.Volume, pool.Length, pool.Height,
                pool.Width, pool.PumpIncluded, pool.Stairway, pool.ImageUrl, pool.CategoryId, employeeId);

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
            var poolId = id;

            this.comments.Create(comment.Text, comment.ProductRankting, id, userId);

            return RedirectToAction(nameof(All));
        }
    }
}
