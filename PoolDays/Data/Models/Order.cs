using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int SpeditorId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime OrderPrice { get; set; }

        public bool PaymentType { get; set; }

        public int PoolId { get; set; }

        public IEnumerable<PoolOrder> PoolOrders { get; set; }
    }
}
