using Eder.Domain.Common;
using Eder.Domain.Enums;

namespace Eder.Domain.Entities;

public class UserRole : BaseEntity
{
    public RoleName Name { get; set; }
    public RoleType Type { get; set; } = RoleType.TENANT;
}
