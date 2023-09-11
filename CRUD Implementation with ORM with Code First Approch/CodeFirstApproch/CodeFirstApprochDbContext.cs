using CodeFirstApproch.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproch
{
    public class CodeFirstApprochDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=.;Initial Catalog=CodeFirstApproach;Integrated Security=True;Encrypt=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Products> Products { get; set; }
    }
}
