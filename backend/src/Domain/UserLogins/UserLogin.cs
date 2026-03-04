using SharedKernel;

namespace Domain.UserLogins;

public sealed class UserLogin:Entity
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string PasswordHash {get; set;}
    public string PhoneNumber {get; set;}

}