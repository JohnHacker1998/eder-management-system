namespace eder_management_system_API.Configuration
{
    public record class JWTConfiguration
    {
        public string Key { get; init; }
        public string Issuer {  get; init; }

        public string Audience { get; init; }

        public int ExpireAccessMinutes { get; init; }

        public int ExpireRefreshMinutes { get; init; }
      
    }
}
