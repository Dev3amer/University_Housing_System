namespace UniversityHousingSystem.Data.Entities
{
    public class HighSchoolDepartment
    {
        public int HighSchoolDepartmentId { get; set; }
        public string Name { get; set; } = default!;

        // Foreign Keys
        public int HighSchoolId { get; set; }

        // Navigation Properties
        public HighSchool HighSchool { get; set; } = new();
    }
}
