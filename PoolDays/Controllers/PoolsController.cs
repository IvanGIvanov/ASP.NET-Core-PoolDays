using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Models.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class PoolsController : Controller
    {
        private readonly PoolDaysDBContext data;

        public PoolsController(PoolDaysDBContext data) 
            => this.data = data;

        public IActionResult Add() => View(new AddPoolFormModel
        {
            Categories = this.GetPoolCategories()
        });

        [HttpPost]
        public IActionResult Add(AddPoolFormModel pool)
        {
            return View();
        }

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
