using Microsoft.AspNetCore.Mvc;
using PoolDays.Data;
using PoolDays.Models.Api;
using PoolDays.Services.Statistics;
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
        private readonly IStatisticsService statistics;

        public StatisticsApiController(IStatisticsService statistics) => this.statistics = statistics;

        [HttpGet]
        public StatisticsServiceModel GetStatistics()
        {
            return this.statistics.AllStatistics();
        }
    }
}
