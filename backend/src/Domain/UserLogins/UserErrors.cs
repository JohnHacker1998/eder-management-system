using SharedKernel;

namespace Domain.Users;

public static class UserErrors
{
    public static Error NotFound(Guid userId) => Error.NotFound(
        "UserLogins.NotFound",
        $"The user login with the Id = '{userId}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "UserLogins.Unauthorized",
        "You are not authorized to perform this action.");

    public static readonly Error NotFoundByEmail = Error.NotFound(
        "UserLogins.NotFoundByEmail",
        "The user login with the specified email was not found");

    public static readonly Error EmailNotUnique = Error.Conflict(
        "UserLogins.EmailNotUnique",
        "The provided email for user login is not unique");
    public static readonly Error PhoneNumberNotUnique = Error.Conflict(
        "UserLogins.PhoneNumberNotUnique",
        "The provided phone number for user login is not unique");
}
