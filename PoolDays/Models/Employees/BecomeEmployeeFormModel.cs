using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Models.Employees
{
    using static PoolDays.Data.DataConstants.Employee;

    public class BecomeEmployeeFormModel
    {

        [Required]
        [StringLength(EmployeeNameMaxValue, MinimumLength = EmployeeNameMinValue)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(EmployeeNumberMaxValue, MinimumLength = EmployeeNumberMinValue)]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
    }
}
