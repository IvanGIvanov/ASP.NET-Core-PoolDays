using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Data.Models
{
    using static PoolDays.Data.DataConstants.Employee;

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EmployeeNameMaxValue)]
        public string Name { get; set; }

        [Required]
        [MaxLength(EmployeeNumberMaxValue)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string UserId { get; set; }

        public IEnumerable<Pool> Pools { get; set; } = new List<Pool>();

    }
}
