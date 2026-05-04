using eder_web_api.common;
using eder_web_api.modules.account.entities;
using eder_web_api.modules.auth.entities;

namespace eder_web_api.modules.user.entities
{
    public class User : BaseEntity
    {
        public required Guid AccountId { get; set; }

        public Account? Account { get; set; } = null;

        public required Guid UserRoleId { get; set; }

        public UserRole? UserRole { get; set; } = null;

        public required Guid UserLoginId { get; set; }

        public UserLogin? UserLogin { get; set; } = null;
    }
}
