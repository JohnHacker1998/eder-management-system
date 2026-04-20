using eder_web_api.common.interfaces;

namespace eder_web_api.common
{
    public abstract class BaseEntity : IAuditedEntity
    {
        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
