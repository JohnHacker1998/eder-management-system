using Microsoft.EntityFrameworkCore;
using Eder.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Eder.Infrastructure.Persistence
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options):IdentityDbContext<User>(options)
    {
        internal DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }
}
