using Eder.Domain.Entities;
using Eder.Infrastructure.Common.Enums;
using eder_management_system_API.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Eder.Infrastructure.Utility
{
    public class JWT(UserManager<User> _userManager,IConfiguration _configuration, JWTConfiguration jwtConfig)
    {
        private readonly JWTConfiguration _jwtConfig = jwtConfig;
        public async Task<List<Claim>> GenerateClaims(IList<Claim> userClaims,IList<Claim> roleClaims,User user)
        {
            List<Claim> claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Name,user.UserName!)
            };
            claims.AddRange(userClaims);
            claims.AddRange(roleClaims); 
            
            return claims;            

        }
       
        public async Task<string> GenerateToken(User user,string type)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();             
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: await GenerateClaims(userClaims, roleClaims, user),
                expires: DateTime.Now.AddMinutes(type == Enums.TokenType.ACCESS.ToString() ? _jwtConfig.ExpireAccessMinutes : _jwtConfig.ExpireRefreshMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
     

    }
}

