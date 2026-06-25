using Eder.Domain.Entities;

namespace Eder.Domain.IRepositories;

public interface IUserRepository
{
    Task<User> Create(User user);
}
