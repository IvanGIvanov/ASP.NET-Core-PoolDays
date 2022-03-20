using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contacts()
        {
            return View();
        }
    }
}
