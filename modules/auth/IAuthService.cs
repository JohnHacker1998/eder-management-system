using eder_management_system.modules.auth.rtos;

namespace eder_management_system.modules.auth
{
    public interface IAuthService
    {
        Task<RegisterResponse> Register(RegisterRequest RegisterRequest);
    }
}
