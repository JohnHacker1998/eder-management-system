using Eder.Domain.Common;
using Eder.Domain.Exceptions;

namespace Eder.Domain.Entities;

public class User : BaseEntity
{
    public Guid AccountId { get; private set; }
    public Account? Account { get; private set; }

    public Guid UserRoleId { get; private set; }
    public UserRole? UserRole { get; private set; }

    public Guid UserLoginId { get; private set; }
    public UserLogin? UserLogin { get; private set; }

    private User() { }

    public static User Create(Guid accountId, Guid userRoleId, Guid userLoginId)
    {
        if (accountId == Guid.Empty)
            throw new DomainValidationException("AccountId is required.");
        if (userRoleId == Guid.Empty)
            throw new DomainValidationException("UserRoleId is required.");
        if (userLoginId == Guid.Empty)
            throw new DomainValidationException("UserLoginId is required.");

        return new User
        {
            AccountId = accountId,
            UserRoleId = userRoleId,
            UserLoginId = userLoginId,
        };
    }
}
