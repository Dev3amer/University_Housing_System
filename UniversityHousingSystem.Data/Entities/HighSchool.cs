namespace UniversityHousingSystem.Data.Entities
{
    public class HighSchool
    {
        public int HighSchoolId { get; set; }
        public string Name { get; set; } = default!;

        // Navigation Properties
        public ICollection<NewStudent>? NewStudents { get; set; }
    }
}
