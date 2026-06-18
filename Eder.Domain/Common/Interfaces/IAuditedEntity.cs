namespace Eder.Domain.Common.Interfaces;

public interface IAuditedEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
}
