using Microsoft.EntityFrameworkCore;
using MyprogectHW.Models;

namespace MyprogectHW
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // Database.EnsureDeleted()
            Database.EnsureCreated();
        }
        public DbSet<Server> Servers { get; set; }
        public DbSet<ServerComponents> Components { get; set; }
        public DbSet<ServerOperationSystem> Operations { get; set; }

    }
}
