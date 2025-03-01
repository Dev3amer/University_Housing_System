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
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
        }
    }
}
