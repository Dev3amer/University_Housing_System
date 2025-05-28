namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetAllViolationsTypeResponse
    {
        public int ViolationTypeId { get; set; }
        public string ViolationTypeName { get; set; } = default!;
    }
}
