namespace eder_management_system.modules.auth
{
    public class RegisterRequest
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Password { get; set; }
    }
}
