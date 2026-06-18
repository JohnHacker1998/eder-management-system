using Eder.Domain.Common.Interfaces;

namespace Eder.Domain.Common
{
    public abstract class BaseEntity : IAuditedEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
