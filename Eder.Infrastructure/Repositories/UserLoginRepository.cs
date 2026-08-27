using Eder.Domain.Entities;
using Eder.Domain.Exceptions;
using Eder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Eder.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace Eder.Infrastructure.Repositories
{
    public class UserLoginRepository(UserManager<ApplicationUser> userManager) : IUserLoginRepository
    {
        public async Task<UserLogin?> GetUserByPhoneNumberAndEmail(string phoneNumber, string email)
        {
            var userLoginData=await userManager.Users.FirstOrDefaultAsync(x =>
                x.PhoneNumber == phoneNumber && x.Email == email);
            return userLoginData != null ? ApplicationUserMapper.ToDomain(userLoginData):null;
        }

        public async Task<UserLogin> Create(UserLogin userLogin, string password, string refreshToken)
        {
            var applicationUser = ApplicationUserMapper.ToApplicationUser(userLogin, refreshToken);
            var result=await userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                throw new IdentityOperationException(
                    "Failed to create user.",
                    result.Errors.Select(e => e.Description)
                );
            }
            return ApplicationUserMapper.ToDomain(applicationUser);
        }
    }
}
