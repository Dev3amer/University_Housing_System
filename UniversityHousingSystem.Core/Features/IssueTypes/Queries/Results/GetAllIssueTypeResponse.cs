namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetAllIssueTypeResponse
    {
        public int IssueTypeId { get; set; }
        public string TypeName { get; set; } = default!;
    }
}
