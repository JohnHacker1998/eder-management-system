using eder_web_api.modules.user.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eder_web_api.modules.users.entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder
                .HasOne(x => x.UserRole)
                .WithMany()
                .HasForeignKey(x => x.UserRoleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.UserLogin)
                .WithMany()
                .HasForeignKey(x => x.UserLoginId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
