using Microsoft.EntityFrameworkCore;
using RawQueryCrudApp.Data;
using RawQueryCrudApp.Models;

namespace RawQueryCrudApp.Repository
{
    public class TodoItemRepository
    {
        private readonly AppDbContext _context;

        public TodoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.FromSqlRaw("SELECT * FROM TodoItems").ToList();
        }

        public TodoItem GetById(int id)
        {
            return _context.TodoItems.FromSqlRaw("SELECT * FROM TodoItems WHERE Id = {0}", id).FirstOrDefault();
        }

        public void Add(TodoItem item)
        {
            _context.Database.ExecuteSqlRaw("INSERT INTO TodoItems (Title, IsCompleted) VALUES ({0}, {1})", item.Title, item.IsCompleted);
        }

        public void Update(TodoItem item)
        {
            _context.Database.ExecuteSqlRaw("UPDATE TodoItems SET Title = {0}, IsCompleted = {1} WHERE Id = {2}", item.Title, item.IsCompleted, item.Id);
        }

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM TodoItems WHERE Id = {0}", id);
        }
    }
}
