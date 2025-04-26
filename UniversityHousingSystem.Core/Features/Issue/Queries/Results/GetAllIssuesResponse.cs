namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetAllIssuesResponse
    {
        public int IssueID { get; set; }
        public string Description { get; set; } = default!;
        public DateTime CreatedDate { get; set; }

        public string StudentName { get; set; } = default!;
        public string? EmployeeName { get; set; }   // optional if assigned
        public string IssueTypeName { get; set; } = default!;
        public string? Response { get; set; }        // optional
    }
}
