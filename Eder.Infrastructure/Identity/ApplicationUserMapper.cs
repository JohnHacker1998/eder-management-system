using Eder.Domain.Entities;

namespace Eder.Infrastructure.Identity;

internal static class ApplicationUserMapper
{
    public static UserLogin ToDomain(ApplicationUser user) =>
        new()
        {
            Id = user.Id,
            Email = user.Email!,
            UserName = user.UserName!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            LoginCount = user.LoginCount,
            RefreshToken = user.RefreshToken,
        };

    public static ApplicationUser ToApplicationUser(UserLogin userLogin, string refreshToken) =>
        new()
        {
            Id = Guid.NewGuid(),
            UserName = userLogin.UserName,
            Email = userLogin.Email,
            PhoneNumber = userLogin.PhoneNumber,
            FirstName = userLogin.FirstName,
            LastName = userLogin.LastName,
            LoginCount = 0,
            RefreshToken = refreshToken,
        };
}
