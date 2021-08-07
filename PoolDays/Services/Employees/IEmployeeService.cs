using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Employees
{
    public interface IEmployeeService
    {
        public bool UserIsEmployee(string userId);

        public int? EmployeeId(string userId);
    }
}
