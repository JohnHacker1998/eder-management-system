using Eder.Domain.Entities;
using Eder.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eder.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        // Domain.UserLogin is not itself EF-mapped; the persisted identity is ApplicationUser.
        builder.Ignore(x => x.UserLogin);

        builder.Property(x => x.UserRoleId).IsRequired();
        builder.Property(x => x.UserLoginId).IsRequired();

        builder
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(x => x.UserLoginId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.UserRole)
            .WithMany()
            .HasForeignKey(x => x.UserRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
