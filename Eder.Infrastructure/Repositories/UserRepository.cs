using Eder.Domain.Entities;
using Eder.Domain.IRepositories;
using Eder.Infrastructure.Persistence;

namespace Eder.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> Create(User user)
    {
        context.TenantUsers.Add(user);
        await context.SaveChangesAsync();
        return user;
    }
}
