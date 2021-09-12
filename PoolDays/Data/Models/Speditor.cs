using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data.Models
{
    public class Speditor
    {
        public int Id { get; set; }

        public string SpeditorName { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
