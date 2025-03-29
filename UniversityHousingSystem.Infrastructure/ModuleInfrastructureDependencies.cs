using Microsoft.Extensions.DependencyInjection;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.implementation;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static void AddModuleInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IVillageRepository, VillageRepository>();
            services.AddTransient<IRoomPhotoRepository, RoomPhotoRepository>();
            services.AddTransient<IGuardianRepository, GuardianRepository>();
            services.AddTransient<IGovernorateRepository, GovernorateRepository>();
        }
    }
}
