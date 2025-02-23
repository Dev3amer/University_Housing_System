using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class OldStudent
    {
        public int OldStudentId { get; set; }
        public EnPreviousYearGrade PreviousYearGrade { get; set; }
        public decimal GradePercentage { get; set; }
        public bool PreviousYearHosting { get; set; }

        // Navigation Property
        public Student Student { get; set; } = new();
    }
}
