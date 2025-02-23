using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class Visit
    {
        public int VisitId { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public DateTime VisitDate { get; set; }
        public EnStatus Status { get; set; } = EnStatus.Pending;

        // Foreign Keys
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; } = new();
    }
}
