using Microsoft.Extensions.DependencyInjection;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Abstractions.Helpers;
using UniversityHousingSystem.Service.implementation;
using UniversityHousingSystem.Service.implementation.Helpers;
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
            services.AddTransient<INewStudentService, NewStudentService>();
            services.AddTransient<IHighSchoolService, HighSchoolService>();
            services.AddTransient<IQRService, QRService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IPasswordGeneratorService, PasswordGeneratorService>();
            services.AddTransient<IIssueTypeService, IssueTypeService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddHttpClient<IDistanceService, DistanceService>();
            services.AddScoped<IRankingService, RankingService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IViolationTypeService, ViolationTypeService>();
            services.AddTransient<IViolationService, ViolationService>();
        }
    }
}
