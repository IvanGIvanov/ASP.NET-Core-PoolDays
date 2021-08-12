using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Jacuzzies
{
    public class JacuzziQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int TotalJacuzzis { get; init; }

        public int JacuzziPerPage { get; init; }

        public IEnumerable<JacuzziServiceModel> Jacuzzis { get; set; }
    }
}
