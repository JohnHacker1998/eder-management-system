using Domain.UserLogins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.UserLogins;

internal sealed class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u=>u.Id).HasDefaultValueSql("generate_typed_id('user_login')");
    }
}