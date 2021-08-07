using PoolDays.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolDays.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PoolDaysDBContext data;

        public EmployeeService(PoolDaysDBContext data)
        {
            this.data = data;
        }

        public bool UserIsEmployee(string userId)
        => this.data
                .Employees
                .Any(e => e.UserId == userId);
    }
}
