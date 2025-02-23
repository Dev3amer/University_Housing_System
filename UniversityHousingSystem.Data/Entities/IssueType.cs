namespace UniversityHousingSystem.Data.Entities
{
    public class IssueType
    {
        public int IssueTypeId { get; set; }
        public string TypeName { get; set; } = default!;

        // Navigation Property
        public ICollection<Issue>? Issues { get; set; }
    }
}
