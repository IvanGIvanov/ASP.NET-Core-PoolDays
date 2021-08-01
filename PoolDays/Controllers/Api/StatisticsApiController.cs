using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly PoolDaysDBContext data;

        public StatisticsApiController(PoolDaysDBContext data) => this.data = data;

        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            return new StatisticsResponseModel
            {
                TotalPools = this.data.Pools.Count(),
                TotalUsers = this.data.Users.Count()
            };
        }
    }
}
