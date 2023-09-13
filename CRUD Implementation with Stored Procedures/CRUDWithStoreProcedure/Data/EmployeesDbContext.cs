using CRUDWithStoreProcedure.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithStoreProcedure.Data
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
