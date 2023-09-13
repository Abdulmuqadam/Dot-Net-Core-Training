using CRUDWithStoreProcedure.Data;
using CRUDWithStoreProcedure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithStoreProcedure.Interfaces
{
    public class EmployeeRepository
    {
        public EmployeesDbContext _context;

        public EmployeeRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public Employee GetEmployee(int employeeID)
        {
            var employees = _context.Employees.FromSqlRaw("EXEC GetEmployee @EmployeeID",
                new SqlParameter("@EmployeeID", employeeID)
            ).ToList();

            if (employees.Count > 0)
            {
                return employees[0];
            }
            else
            {
                return null;
            }
        }
    }
}
