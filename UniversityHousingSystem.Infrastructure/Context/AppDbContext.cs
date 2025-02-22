using Microsoft.EntityFrameworkCore;
using System.Data;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Context
{
    public class AppDbContext : DbContext
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
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
      
        public DbSet<StudentHistory> StudentHistories { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<OldStudent> OldStudents { get; set; }
        public DbSet<NewStudent> NewStudents { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<HighSchoolDepartment> HighSchoolDepartments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }



        protected AppDbContext()
        {
        }

    }
}
