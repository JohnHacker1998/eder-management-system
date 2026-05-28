using System.Security.Claims;
using eder_management_system.common.config;
using eder_management_system.common.helpers;
using eder_management_system.modules.auth.rtos;
using eder_web_api.Infrastructure.Persistence;
using eder_web_api.modules.auth.entities;
using eder_web_api.modules.auth.enums;
using eder_web_api.modules.user.entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace eder_management_system.modules.auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<UserLogin> _userManager;
        private readonly JwtService _jwtService;
        private readonly JwtOptions _jwtOptions;

        public AuthService(
            AppDbContext context,
            UserManager<UserLogin> userManager,
            JwtService jwtService,
            IOptions<JwtOptions> jwtOptions
        )
        {
            _context = context;
            _userManager = userManager;
            _jwtService = jwtService;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<RegisterResponse> Register(RegisterRequest Request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                int IsEmailExisting = await _context
                    .UserLogins.Where(x => x.Email.Equals(Request.Email))
                    .CountAsync();
                if (IsEmailExisting > 0)
                {
                    throw new Exception("Email already exists");
                }

                int IsPhoneNumberExisting = await _context
                    .UserLogins.Where(x => x.PhoneNumber.Equals(Request.PhoneNumber))
                    .CountAsync();
                if (IsPhoneNumberExisting > 0)
                {
                    throw new Exception("Phone number already exists");
                }

                var User = new UserLogin
                {
                    Email = Request.Email,
                    UserName = Request.Email,
                    FirstName = Request.FirstName,
                    LastName = Request.LastName,
                    PhoneNumber = Request.PhoneNumber,
                };
                var result = await _userManager.CreateAsync(User, Request.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create the user: {errors}");
                }

                var defaultRole = RoleName.CHAIR_PERSON.ToString();
                var roleResult = await _userManager.AddToRoleAsync(User, defaultRole);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to assign role: {errors}");
                }

                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, User.Id.ToString()),
                    new(ClaimTypes.Name, User.UserName ?? User.Email ?? string.Empty),
                    new(ClaimTypes.Email, User.Email ?? string.Empty),
                    new(ClaimTypes.GivenName, User.FirstName),
                    new(ClaimTypes.Surname, User.LastName),
                    new(ClaimTypes.Role, defaultRole),
                };

                var accessToken = _jwtService.GenerateAccessToken(claims);
                var refreshToken = _jwtService.GenerateRefreshToken();
                User.RefreshToken = refreshToken;

                var updateResult = await _userManager.UpdateAsync(User);
                if (!updateResult.Succeeded)
                {
                    var errors = string.Join(", ", updateResult.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to store refresh token: {errors}");
                }

                await transaction.CommitAsync();

                return new RegisterResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = $"{_jwtOptions.AccessTokenMinutes}m",
                };
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
