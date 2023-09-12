using Microsoft.EntityFrameworkCore;

namespace InvokeWebApi.Data
{
    public class InvokeWebApiContext : DbContext
    {
        public InvokeWebApiContext(DbContextOptions<InvokeWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<InvokeWebApi.Model.Crypto> Crypto { get; set; } = default!;
    }
}
