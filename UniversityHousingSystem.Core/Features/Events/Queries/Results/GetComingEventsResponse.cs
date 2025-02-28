namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetComingEventsResponse
    {
        public int EventId { get; set; }
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; } = default!;
    }
}
