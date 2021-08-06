using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Jacuzzi
{
    public class JacuzziQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int TotalJacuzzies { get; init; }

        public int JacuzziPerPage { get; init; }

        public IEnumerable<JacuzziServiceModel> Jacuzzies { get; set; }
    }
}
