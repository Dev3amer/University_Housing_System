using Microsoft.Extensions.DependencyInjection;
using UniversityHousingSystem.Infrastructure.GenericBases;

namespace UniversityHousingSystem.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static void AddModuleInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        }
    }
}
