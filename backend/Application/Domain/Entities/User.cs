using Microsoft.AspNetCore.Identity;

namespace Eder.Domain.Entities
{
    public class User:IdentityUser
    {
        public string RefreshToken { get; set; } = String.Empty;

        public DateOnly DateOfBirth { get; set; }

    }
}
