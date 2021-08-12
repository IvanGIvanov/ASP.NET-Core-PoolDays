using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoolDays.Models.Pools;
using PoolDays.Services.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PoolDays.WebConstants;

namespace PoolDays.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPoolService pools;

        [Authorize(Roles = AdministatorRoleName)]
        [HttpGet("{Admin}")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
