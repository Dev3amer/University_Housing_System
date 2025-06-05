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
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();
            services.AddTransient<ICollegeDepartmentRepository, CollegeDepartmentRepository>();
            services.AddTransient<IOldStudentRepository, OldStudentRepository>();
            services.AddTransient<INewStudentRepository, NewStudentRepository>();
            services.AddTransient<IHighSchoolRepository, HighSchoolRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IIssueTypeRepository, IssueTypeRepository>();
            services.AddTransient<IIssueRepository, IssueRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IViolationTypeRepository, ViolationTypeRepository>();
            services.AddTransient<IViolationRepository, ViolationRepository>();
            services.AddTransient<IStudentHistoryRepository, StudentHistoryRepository>();
            services.AddTransient<IStudentRegistrationRepository, StudentRegistrationRepository>();
        }
    }
}
