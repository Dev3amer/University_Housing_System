namespace UniversityHousingSystem.Data.Entities
{
    public class HighSchool
    {
        public int HighSchoolId { get; set; }
        public string Name { get; set; } = default!;

        // Navigation Properties
        public ICollection<HighSchoolDepartment>? HighSchoolDepartment { get; set; }
        public ICollection<NewStudent>? NewStudents { get; set; }
    }
}
