using PoolDays.Data;
using System.Linq;

namespace PoolDays.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PoolDaysDBContext data;

        public EmployeeService(PoolDaysDBContext data)
        {
            this.data = data;
        }

        public int? EmployeeId(string userId)
            => this.data
                .Employees
                .Where(e => e.UserId == userId)
                .Select(e => e.Id)
                .FirstOrDefault();

        public bool UserIsEmployee(string userId)
        => this.data
                .Employees
                .Any(e => e.UserId == userId);
    }
}
