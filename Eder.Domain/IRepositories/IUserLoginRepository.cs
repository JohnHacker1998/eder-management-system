using Eder.Domain.Entities;
namespace Eder.Domain.IRepositories;

public interface IUserLoginRepository
{
    public Task<UserLogin?> GetUserByPhoneNumberAndEmail(string phone, string email);
    public Task<UserLogin> Create(UserLogin userLogin, string password,string refreshToken);
}
