using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
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
        public IEnumerable PoolGet()
        {
            return this.data.Pools.ToList();
        }
    }
}
