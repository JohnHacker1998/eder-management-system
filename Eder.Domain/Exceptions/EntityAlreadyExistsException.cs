namespace Eder.Domain.Exceptions;

public sealed class EntityAlreadyExistsException : DomainException
{
    public EntityAlreadyExistsException(string entityName, string identifier)
        : base($"{entityName} already exists for '{identifier}'.") { }
}
