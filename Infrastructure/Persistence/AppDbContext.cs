using eder_web_api.modules.auth.entities;

using Microsoft.EntityFrameworkCore;

namespace eder_web_api.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<UserLogin> UserLogins => Set<UserLogin>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Apply all configurations automatically
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // 2. Apply global conventions (optional)
            ApplySnakeCase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ApplySnakeCase(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ToSnakeCase(entity.GetTableName()!));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.Name));
                }
            }
        }

        private static string ToSnakeCase(string name)
        {
            return string.Concat(
                name.Select((c, i) =>
                    i > 0 && char.IsUpper(c)
                        ? "_" + char.ToLower(c)
                        : char.ToLower(c).ToString()
                )
            );
        }
    }
}
