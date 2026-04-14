using eder_web_api.common.interfaces;
using Microsoft.AspNetCore.Identity;

namespace eder_web_api.modules.auth.entities
{
    public class UserLogin :IdentityUser<Guid>,IAuditedEntity
    {
    public required string FirstName{get;set;}  
    public required string LastName{get;set;}
    public int LoginCount{get;set;}

    public string RefreshToken{get;set;}=string.Empty;

    public DateTime CreatedAt { get;set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt {get;set;}
    public DateTime? DeletedAt {get;set;}
        
    }
}