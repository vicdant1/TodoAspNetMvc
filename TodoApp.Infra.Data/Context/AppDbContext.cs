using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Identity;

namespace TodoApp.Infra.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Domain.Entities.Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

    }
}
