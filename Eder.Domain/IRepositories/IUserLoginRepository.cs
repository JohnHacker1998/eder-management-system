using Eder.Domain.Entities;
namespace Eder.Domain.IRepositories;

public interface IUserLoginRepository
{
    public Task<UserLogin> Create(UserLogin userLogin, string password);
}
