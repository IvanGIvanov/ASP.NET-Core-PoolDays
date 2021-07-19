﻿using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
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
            if (this.data.Categories.Any(p => p.Id == pool.CategoryId))
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
                Height = pool.Height,
                Width = pool.Width,
                PumpIncluded = pool.PumpIncluded,
                Stairway = pool.Stairway,
                ImageUrl = pool.ImageUrl,
                CategoryId = pool.CategoryId
            };

            this.data.Pools.Add(poolData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
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
