using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Models.Api.Pools;
using PoolDays.Models.Pools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PoolDays.Controllers.Api
{
    [ApiController]
    [Route("api/pools")]
    public class PoolsApiController : ControllerBase
    {
        private readonly PoolDaysDBContext data;

        public PoolsApiController(PoolDaysDBContext data) => this.data = data;

        [HttpGet]
        public ActionResult<AllPoolsResponseApiModel> All([FromQuery] AllPoolsRequestApiModel query)
        {
            var poolQueriable = this.data.Pools.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Manufacturer))
            {
                poolQueriable = poolQueriable
                    .Where(p => p.Manufacturer == query.Manufacturer);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                poolQueriable = poolQueriable
                    .Where(p => p.Manufacturer.ToLower().Contains(query.SearchTerm.ToLower())
                    || p.Model.ToLower().Contains(query.SearchTerm.ToLower())
                    || p.Description.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            poolQueriable = query.Sorting switch
            {
                PoolSorting.Manufacturer => poolQueriable.OrderBy(p => p.Manufacturer),
                PoolSorting.Volume => poolQueriable.OrderByDescending(p => p.Volume),
                PoolSorting.DateCreated or _ => poolQueriable.OrderByDescending(p => p.Id)
            };

            var totalPools = poolQueriable.Count();

            var pools = poolQueriable
                .Skip((query.CurrentPage - 1) * query.PoolsPerPage)
                .Take(query.PoolsPerPage)
                .Select(p => new PoolResponseModel
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

            return new AllPoolsResponseApiModel
            {
                CurrentPage = query.CurrentPage,
                PoolsPerPage = query.PoolsPerPage,
                TotalPools = totalPools,
                Pools = pools
            };
        }

        [Route("{id}")]
        public ActionResult<Pool> PoolGetById(int id)
        {
            var pool = this.data.Pools.Find(id);

            if (pool == null)
            {
                return NotFound();
            }

            return pool;
        }
    }
}
