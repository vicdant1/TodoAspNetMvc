using Microsoft.EntityFrameworkCore;

namespace TodoApp.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domain.Entities.Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

    }
}
