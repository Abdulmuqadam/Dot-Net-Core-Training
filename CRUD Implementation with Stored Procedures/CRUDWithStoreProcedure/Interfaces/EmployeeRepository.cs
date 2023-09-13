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

        public List<Employee> GetEmployees()
        {            
            var employees = _context.Employees.FromSqlRaw("EXEC GetEmployees").ToList();            
            return employees;
        }

        public Employee GetEmployeeById(int employeeID)
        {
            var employees = _context.Employees.FromSqlRaw("EXEC GetEmployeeById @EmployeeID",
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

        public void CreateEmployee(Employee employee)
        {
            _context.Database.ExecuteSqlRaw("EXEC CreateEmployee @FirstName, @LastName, @Email, @Salary",
            new SqlParameter("@FirstName", employee.FirstName),
            new SqlParameter("@LastName", employee.LastName),
            new SqlParameter("@Email", employee.Email),
            new SqlParameter("@Salary", employee.Salary));
        }

        public void UpdateEmployee(Employee employee)
        {            
            _context.Database.ExecuteSqlRaw("EXEC UpdateEmployee @EmployeeID, @FirstName, @LastName, @Email, @Salary",
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Salary", employee.Salary)
            );
        }

        public void DeleteEmployee(int employeeID)
        {           
            _context.Database.ExecuteSqlRaw("EXEC DeleteEmployee @EmployeeID",
                new SqlParameter("@EmployeeID", employeeID)
            );
        }
    }
}
