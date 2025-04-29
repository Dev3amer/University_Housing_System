namespace UniversityHousingSystem.Data.Entities
{
    public class Issue
    {
        public int IssueId { get; set; }
        public string Description { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ResponseDate { get; set; }
        public string? Response { get; set; }

        //Foreign Keys
        public int IssueTypeId { get; set; }
        public int StudentId { get; set; }
        public int? EmployeeId { get; set; }

        // Navigation Properties
        public IssueType IssueType { get; set; } = new();
        public Student Student { get; set; } = default!;
        public Employee? Employee { get; set; }
    }
}
