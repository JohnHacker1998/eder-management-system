namespace Eder.Domain.Exceptions;

public sealed class IdentityOperationException : DomainException
{
    public IReadOnlyCollection<string> Errors { get; }

    public IdentityOperationException(string message, IEnumerable<string> errors)
        : base(message)
    {
        Errors = errors.ToList();
    }
}
