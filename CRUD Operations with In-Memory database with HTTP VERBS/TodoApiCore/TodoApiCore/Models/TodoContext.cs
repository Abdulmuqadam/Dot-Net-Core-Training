using Microsoft.EntityFrameworkCore;
using TodoApiCore.Models;
namespace TodoApiCore.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        { 
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public DbSet<TodoApiCore.Models.TodoItemDTO> TodoItemDTO { get; set; } = default!;
    }
}
