using Microsoft.Extensions.DependencyInjection;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.implementation;

namespace UniversityHousingSystem.Service
{
    public static class ModuleServiceDependencies
    {
        public static void AddModuleServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
        }
    }
}
