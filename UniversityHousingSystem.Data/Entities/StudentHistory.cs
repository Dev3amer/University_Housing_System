namespace UniversityHousingSystem.Data.Entities
{
    public class StudentHistory
    {
        public int StudentHistoryId { get; set; }
        public DateTime From { get; set; } = DateTime.UtcNow;
        public DateTime? To { get; set; }

        // Foreign Keys
        public int StudentId { get; set; }

        // Navigation Properties
        public Student Student { get; set; } = new();
        public ICollection<Violation>? Violations { get; set; }
    }
}
