namespace UniversityHousingSystem.Data.Entities
{
    public class NewStudent
    {
        public int NewStudentId { get; set; }
        public decimal HighSchoolPercentage { get; set; }

        //Foreign Keys
        public int HighSchoolId { get; set; }
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; } = new();
        public HighSchool? HighSchool { get; set; }
    }
}
