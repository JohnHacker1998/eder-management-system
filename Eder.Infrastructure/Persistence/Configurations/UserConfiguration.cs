using Eder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eder.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.Ignore(x => x.UserRole);
        builder.Ignore(x => x.UserLogin);
        builder.Property(x => x.UserRoleId).IsRequired();
        builder.Property(x => x.UserLoginId).IsRequired();
    }
}
