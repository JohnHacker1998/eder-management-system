namespace eder_management_system.modules.auth.rtos
{
    public class RegisterResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public string ExpiresIn { get; set; }
    }
}
