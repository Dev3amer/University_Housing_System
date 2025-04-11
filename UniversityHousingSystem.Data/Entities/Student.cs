using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string? Telephone { get; set; }
        public DateOnly BirthDate { get; set; }
        public EnGender Gender { get; set; }
        public EnReligion Religion { get; set; }
        public string PlaceOfBirth { get; set; } = default!;
        public bool HasSpecialNeeds { get; set; }
        public string AcademicStudentCode { get; set; } = default!;
        public string AcademicYear { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsMarried { get; set; }
        public string AddressLine { get; set; } = default!;
        public string? StudentQR { get; set; }

        //Foreign Keys
        public int ApplicationId { get; set; }
        public int CollegeId { get; set; }
        public int GuardianId { get; set; }
        public int CountryId { get; set; }
        public string? UserId { get; set; }
        public int? RoomId { get; set; }
        public int ResidencePlace { get; set; } //Foreign Key For Village

        // Navigation Properties
        public Guardian Guardian { get; set; } = new();
        public ICollection<Document> Documents { get; set; } = new HashSet<Document>();
        public Village Village { get; set; } = new();
        public Country Country { get; set; } = new();
        public ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
        public College College { get; set; } = new();
        public Application Application { get; set; } = new();
        public Room? Room { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<StudentHistory>? Histories { get; set; }

        public OldStudent? OldStudent { get; set; }
        public NewStudent? NewStudent { get; set; }
        public virtual ICollection<StudentsNotifications>? StudentsNotifications { get; set; }
        public ICollection<Visit>? Visits { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
        public ICollection<Response>? Responses { get; set; }

    }
}
