using Microsoft.EntityFrameworkCore;
using StoredProcedurewithEFCore.Data;
using StoredProcedurewithEFCore.Models;

namespace StoredProcedurewithEFCore.Repository
{
    public class UserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            var users = _context.Users.FromSqlRaw("exec GetAllUsers").ToList();
            return users;
        }
    }
}
