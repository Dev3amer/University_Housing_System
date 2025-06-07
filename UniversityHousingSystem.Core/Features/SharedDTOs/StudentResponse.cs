using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.SharedDTOs
{
    public class StudentResponse
    {
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
        public double CurrentScore { get; set; }
        public string? QRImagePath { get; set; }
        public int GuardianId { get; set; }
        public string GuardianFullName { get; set; } = default!;
        public string GuardianPhone { get; set; } = default!;

    }
}
