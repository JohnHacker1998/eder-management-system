using Eder.Domain.Common;

namespace Eder.Domain.Entities;

public class User : BaseEntity
{
    public required Guid AccountId { get; set; }
    public Account? Account { get; set; }

    public required Guid UserRoleId { get; set; }
    public UserRole? UserRole { get; set; }

    public required Guid UserLoginId { get; set; }
    public UserLogin? UserLogin { get; set; }
}
