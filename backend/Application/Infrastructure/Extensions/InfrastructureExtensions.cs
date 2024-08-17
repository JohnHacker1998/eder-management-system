using Eder.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Eder.Infrastructure.Extensions;

    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection _services, IConfiguration _configuration)
        {
            var ConnectionString = _configuration.GetConnectionString("local");
            _services.AddDbContext<AppDbContext>(options=>options.UseNpgsql(ConnectionString));    
        } 
    }

