using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data.Models
{
    public class PoolOrder
    {
        public int PoolId { get; set; }

        public Pool Pool { get; set; }

        public string UserId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
