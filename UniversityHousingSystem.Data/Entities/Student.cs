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
        public DateOnly BirthDate { get; set; }
        public EnGender Gender { get; set; }
        public EnReligion Religion { get; set; }
        public bool HasSpecialNeeds { get; set; }
        public string AcademicStudentCode { get; set; } = default!;
        public string AcademicYear { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsMarried { get; set; }
        public string QRText { get; set; } = default!;
        public string? QRImagePath { get; set; }
        public double CurrentScore { get; set; }
        public int RegistrationCodeId { get; set; }

        //Foreign Keys
        public int ApplicationId { get; set; }
        public int CollegeId { get; set; }
        public int CollegeDepartmentId { get; set; }
        public int GuardianId { get; set; }
        public string? UserId { get; set; }
        public int? RoomId { get; set; }
        public int CountryId { get; set; }
        public int? GovernorateId { get; set; }
        public int? CityId { get; set; }
        public int? VillageId { get; set; }

        // Navigation Properties
        public StudentRegistrationCode StudentRegistrationCode { get; set; } = default!;
        public Guardian Guardian { get; set; } = default!;
        public ICollection<Document> Documents { get; set; } = new HashSet<Document>();
        public Country Country { get; set; } = default!;
        public Governorate? Governorate { get; set; }
        public City? City { get; set; }
        public Village? Village { get; set; }
        public ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
        public College College { get; set; } = default!;
        public CollegeDepartment CollegeDepartment { get; set; } = default!;
        public Application Application { get; set; } = default!;
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
