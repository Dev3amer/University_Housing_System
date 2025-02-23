namespace UniversityHousingSystem.Data.Entities
{
    public class College
    {
        public int CollegeId { get; set; }
        public string Name { get; set; } = default!;

        // Navigation Property
        public ICollection<CollegeDepartment>? Departments { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
