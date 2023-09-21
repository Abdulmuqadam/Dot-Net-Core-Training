using Microsoft.EntityFrameworkCore;
using RawQueryCrudApp.Models;

namespace RawQueryCrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
