using Eder.Domain.Entities;

namespace Eder.Domain.IRepositories;

public interface IAccountRepository
{
    Task<Account> Create(Account account);
}
