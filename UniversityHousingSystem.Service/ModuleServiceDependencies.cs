using Microsoft.Extensions.DependencyInjection;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.implementation;
using UniversityHousingSystem.Service.Implementation;

namespace UniversityHousingSystem.Service
{
    public static class ModuleServiceDependencies
    {
        public static void AddModuleServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IVillageService, VillageService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IGuardianService, GuardianService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IGovernorateService, GovernorateService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICollegeService, CollegeService>();
            services.AddTransient<ICollegeDepartmentService, CollegeDepartmentService>();
            services.AddTransient<IOldStudentService, OldStudentService>();
        }
    }
}
