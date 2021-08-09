using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoolDays.Data;
using PoolDays.Models;
using PoolDays.Models.Home;
using PoolDays.Services.Statistics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        private readonly PoolDaysDBContext data;
        private readonly IMapper mapper;

        public HomeController(IStatisticsService statistics, PoolDaysDBContext data, IMapper mapper)
        {
            this.statistics = statistics;
            this.data = data;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var pools = this.data
                .Pools
                .OrderByDescending(p => p.Id)
                .ProjectTo<PoolIndexViewModel>(this.mapper.ConfigurationProvider)
                .Take(3)
                .ToList();

            var allStatistics = this.statistics.AllStatistics();

            return View(new IndexViewModel
            { 
                TotalUsers = allStatistics.TotalUsers,
                TotalPools = allStatistics.TotalPools,
                Pools = pools,
            });
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }
}
