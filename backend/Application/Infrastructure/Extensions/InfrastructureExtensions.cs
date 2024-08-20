using Eder.Domain.Entities;
using Eder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eder.Infrastructure.Extensions;

    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration _configuration)
        {
            var ConnectionString = _configuration.GetConnectionString("local");
            services.AddDbContext<AppDbContext>(options=>options.UseNpgsql(ConnectionString));
        services.AddIdentityCore<User>()
                 .AddEntityFrameworkStores<AppDbContext>();
        
        

    } 
    }

