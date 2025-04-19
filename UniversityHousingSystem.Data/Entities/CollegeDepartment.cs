namespace UniversityHousingSystem.Data.Entities
{
    public class CollegeDepartment
    {
        public int CollegeDepartmentId { get; set; }
        public string Name { get; set; } = default!;

        // Foreign Keys
        public int CollegeId { get; set; }

        // Navigation Property
        public College College { get; set; } = new();
    }
}
