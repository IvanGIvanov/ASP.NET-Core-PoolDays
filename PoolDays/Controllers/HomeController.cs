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

        public HomeController(IStatisticsService statistics, PoolDaysDBContext data)
        {
            this.statistics = statistics;
            this.data = data;
        }

        public IActionResult Index()
        {
            var pools = this.data
                .Pools
                .OrderByDescending(p => p.Id)
                .Select(p => new PoolIndexViewModel
                {
                    Id = p.Id,
                    Manufacturer = p.Manufacturer,
                    Model = p.Model,
                    Description = p.Description,
                    Volume = p.Volume,
                    Height = p.Height,
                    Length = p.Length,
                    Width = p.Width,
                    ImageUrl = p.ImageUrl,
                })
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
