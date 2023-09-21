using File_Upload_And_Download_Through_Db.Model;
using Microsoft.EntityFrameworkCore;

namespace File_Upload_And_Download_Through_Db.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FileEntity> Files { get; set; }

    }
}
