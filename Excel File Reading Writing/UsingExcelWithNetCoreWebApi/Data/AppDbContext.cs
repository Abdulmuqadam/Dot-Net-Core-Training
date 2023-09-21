using Microsoft.EntityFrameworkCore;
using UsingExcelWithNetCoreWebApi.Models;

namespace UsingExcelWithNetCoreWebApi.Data
{
    public class AppDbContext : DbContext
    {       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }
    }
}
