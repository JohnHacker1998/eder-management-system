using Eder.Application.Auth.Dtos;
using FluentValidation;

namespace Eder.Application.Auth.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.FirstName).MinimumLength(1).MaximumLength(150).NotNull();
        RuleFor(x => x.LastName).MinimumLength(1).MaximumLength(150).NotNull();
        RuleFor(x => x.Email)
            .Custom(
                (email, context) =>
                {
                    var normalized = email.Trim().ToLowerInvariant();
                    context.InstanceToValidate.Email = normalized;
                }
            )
            .EmailAddress();
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+2519\d{8}$")
            .WithMessage("Phone number must be in format +2519XXXXXXXX.");
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[a-z]")
            .WithMessage("Password must contain lowercase letter")
            .Matches("[A-Z]")
            .WithMessage("Password must contain uppercase letter")
            .Matches("[0-9]")
            .WithMessage("Password must contain a digit")
            .Matches("[^a-zA-Z0-9]")
            .WithMessage("Password must contain a special character");
    }
}
