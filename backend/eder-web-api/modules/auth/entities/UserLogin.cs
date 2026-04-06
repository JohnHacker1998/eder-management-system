using eder_web_api.common;

namespace eder_web_api.modules.auth.entities
{
    public class UserLogin:BaseEntity{
    
    public required string FirstName{get;set;}  
    public required string LastName{get;set;}
    public required string Email{get;set;}

    public required string Password{get;set;}

    public required string PasswordHash{get;set;}

    public string? ResetPasswordCode{get;set;}

    public string? ResetPasswordSecret{get;set;}

    public required string PhoneNumber{get;set;}

    public int LoginCount{get;set;}
        
    }
}