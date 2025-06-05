using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<CollegeDepartment> CollegeDepartments { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomPhoto> RoomPhotos { get; set; }

        public DbSet<Response> Responses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<StudentHistory> StudentHistories { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<OldStudent> OldStudents { get; set; }
        public DbSet<NewStudent> NewStudents { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<StudentRegistrationCode> StudentRegistrationCodes { get; set; }
        public DbSet<RegistrationPeriod> RegistrationPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
