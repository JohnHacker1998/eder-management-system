using eder_web_api.common;
using eder_web_api.modules.user.entities;

namespace eder_web_api.modules.account.entities
{
    public class Account : BaseEntity
    {
        public required string Name { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
