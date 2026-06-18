using Eder.Domain.Common;

namespace Eder.Domain.Entities;

public class Account : BaseEntity
{
    public required string Name { get; set; }
    public ICollection<User> Users { get; set; } = [];
}
