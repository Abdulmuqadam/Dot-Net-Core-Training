using BasicAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicAuth
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options) 
        {
        }

        public DbSet<UserAuth> userAuths { get; set; }
    }
}