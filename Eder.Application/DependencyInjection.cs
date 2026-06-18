using Eder.Application.Auth.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Eder.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
        return services;
    }
}
