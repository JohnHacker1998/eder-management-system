using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eder_web_api.modules.auth.entities
{
    public class UserLoginConfiguration:IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("user_logins");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ResetPasswordCode).HasMaxLength(255);
            builder.Property(x => x.ResetPasswordSecret).HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property(x => x.LoginCount).HasDefaultValue(0);

            builder.HasIndex(x =>x.Email).IsUnique();
            builder.HasIndex(x=>x.PhoneNumber).IsUnique();

        }
    }
}
