using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Data.Models;
using PoolDays.Models.Api.Pools;
using PoolDays.Models.Pools;
using PoolDays.Services;
using PoolDays.Services.Pools;
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
        private readonly IPoolService pools;

        public PoolsApiController(IPoolService pools) => this.pools = pools;

        [HttpGet]
        public PoolQueryServiceModel All([FromQuery] AllPoolsRequestApiModel query)
        {
            return this.pools.All(
                query.Manufacturer,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.PoolsPerPage);
        }
    }
}
