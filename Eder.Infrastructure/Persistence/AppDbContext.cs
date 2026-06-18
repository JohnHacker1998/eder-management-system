using Eder.Domain.Entities;
using Eder.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Eder.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<ApplicationUser> UserLogins => Set<ApplicationUser>();
    public DbSet<ApplicationRole> UserRoles => Set<ApplicationRole>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
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
            name.Select(
                (c, i) =>
                    i > 0 && char.IsUpper(c)
                        ? "_" + char.ToLower(c)
                        : char.ToLower(c).ToString()
            )
        );
    }
}
