namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetEventByIdResponse
    {
        public int EventId { get; set; }
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; } = default!;
    }
}
