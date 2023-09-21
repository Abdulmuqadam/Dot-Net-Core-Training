using AuthJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthJwt.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<UserAuth> Users { get; set; }
    }
}
