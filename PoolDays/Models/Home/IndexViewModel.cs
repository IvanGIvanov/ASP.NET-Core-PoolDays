using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Home
{
    public class IndexViewModel
    {
        public int TotalPools { get; set; }

        public int TotalUsers { get; set; }

        public List<PoolIndexViewModel> Pools { get; set; }
    }
}
