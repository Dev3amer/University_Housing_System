namespace UniversityHousingSystem.Data.Entities
{
    public class Violation
    {
        public int ViolationId { get; set; }
        public DateTime ViolationDate { get; set; }

        // Foreign Keys
        public int ViolationTypeId { get; set; }
        public int StudentHistoryId { get; set; }

        // Navigation Properties
        public ViolationType ViolationType { get; set; } = new();
        public StudentHistory StudentHistory { get; set; } = new();
    }
}
