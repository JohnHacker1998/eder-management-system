using Eder.Domain.Entities;
using Eder.Domain.Enums;
using Eder.Domain.IRepositories;
using Eder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Eder.Infrastructure.Repositories;

public class UserRoleRepository(AppDbContext context) : IUserRoleRepository
{
    public async Task<UserRole?> GetRoleByName(RoleName roleName)
    {
       return await context.TenantUserRoles.FirstOrDefaultAsync(x => x.Name == roleName);
    }
}
