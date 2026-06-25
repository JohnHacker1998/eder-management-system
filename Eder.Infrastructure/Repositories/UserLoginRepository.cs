using Eder.Domain.Entities;
using Eder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Eder.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace Eder.Infrastructure.Repositories
{
    public class UserLoginRepository(UserManager<ApplicationUser> userManager,JwtService jwtService) : IUserLoginRepository
    {
        public async Task<UserLogin?> GetUserByPhoneNumberAndEmail(string phoneNumber, string email)
        {
            var userLoginData=await userManager.Users.FirstOrDefaultAsync(x =>
                x.PhoneNumber == phoneNumber && x.Email == email);
            return userLoginData != null ? MapToDomain(userLoginData):null;
        }
        
        public async Task<UserLogin> Create(UserLogin userLogin, string password, string refreshToken)
        {
            var applicationUser= new ApplicationUser()
            {
                Id=Guid.NewGuid(),
                UserName = userLogin.UserName,
                Email = userLogin.Email,
                PhoneNumber = userLogin.PhoneNumber,
                FirstName = userLogin.FirstName,
                LastName = userLogin.LastName,
                LoginCount = 0,
                RefreshToken = refreshToken
            };
            var user=await userManager.CreateAsync(applicationUser, password);
            if (!user.Succeeded)
            {
                throw new Exception("Failed to create user");
            }
            return MapToDomain(applicationUser);
        }
        
        private static UserLogin MapToDomain(ApplicationUser user) => new()
        {
            Id = user.Id,
            Email = user.Email!,
            UserName = user.UserName!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            LoginCount = user.LoginCount,
            RefreshToken = user.RefreshToken,
        };
    }
}
