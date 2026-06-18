using Microsoft.AspNetCore.Identity;

namespace Eder.Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public int RoleType { get; set; } = 1;
    }
}
