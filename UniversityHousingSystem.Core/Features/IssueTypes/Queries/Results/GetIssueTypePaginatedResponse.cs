namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetIssueTypePaginatedResponse
    {
        public int IssueTypeId { get; set; }
        public string TypeName { get; set; } = default!;
        
    }
}
