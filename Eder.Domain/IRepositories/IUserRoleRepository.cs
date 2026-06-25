using Eder.Domain.Entities;
using Eder.Domain.Enums;

namespace Eder.Domain.IRepositories;

public interface IUserRoleRepository
{
    public Task<UserRole?> GetRoleByName(RoleName roleName);
}
