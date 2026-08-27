using Eder.Domain.Common;
using Eder.Domain.Exceptions;

namespace Eder.Domain.Entities;

public class Account : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public ICollection<User> Users { get; private set; } = [];

    private Account() { }

    public static Account Create(string firstName, string lastName)
    {
        var name = $"{firstName} {lastName}".Trim();
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainValidationException("Account name cannot be empty.");

        return new Account { Name = name };
    }
}
