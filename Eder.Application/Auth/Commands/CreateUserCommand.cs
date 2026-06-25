using Eder.Application.Auth.Dtos;
using Eder.Application.Common;
using Eder.Domain.Entities;
using Eder.Domain.Enums;
using Eder.Domain.IRepositories;
using MediatR;

namespace Eder.Application.Auth.Commands;

public record CreateUserCommand(RegisterRequest Request) : IRequest<RegisterResponse>;

public class CreateUserCommandHandler(
    IUserLoginRepository userLoginRepository,
    IUserRoleRepository userRoleRepository,
    IAccountRepository accountRepository,
    IUserRepository userRepository,
    ITokenService tokenService
) : IRequestHandler<CreateUserCommand, RegisterResponse>
{
    public async Task<RegisterResponse> Handle(
        CreateUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var request = command.Request;

        var existing = await userLoginRepository.GetUserByPhoneNumberAndEmail(
            request.PhoneNumber,
            request.Email
        );
        if (existing is not null)
            throw new InvalidOperationException("User already exists.");

        var role = await userRoleRepository.GetRoleByName(RoleName.USER);
        if (role is null)
            throw new InvalidOperationException("Default role 'USER' is not configured.");

        var refreshToken = tokenService.GenerateRefreshToken();

        var userLogin = new UserLogin
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email,
            PhoneNumber = request.PhoneNumber,
            RefreshToken = refreshToken,
        };

        var createdLogin = await userLoginRepository.Create(
            userLogin,
            request.Password,
            refreshToken
        );

        var account = await accountRepository.Create(
            new Account { Name = $"{request.FirstName} {request.LastName}" }
        );

        var user = await userRepository.Create(
            new User
            {
                AccountId = account.Id,
                UserRoleId = role.Id,
                UserLoginId = createdLogin.Id,
            }
        );

        return new RegisterResponse
        {
            AccessToken = tokenService.GenerateAccessToken(user.Id),
            RefreshToken = refreshToken,
            ExpiresIn = string.Empty,
        };
    }
}
