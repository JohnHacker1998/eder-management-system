using Eder.Domain.Common;

namespace Eder.Domain.Entities;

public class UserLogin : BaseEntity
{
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public int LoginCount { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
}
