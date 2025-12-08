using BCTECHAPI.Core.Interfaces;
using BCTECHAPI.Infrastructure.Repositories;

namespace ServicesExtension
{
        public static class ServiceRegistration
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Repo
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            // Services
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }

}