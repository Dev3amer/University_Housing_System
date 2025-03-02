namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetAllBuildingResponse
    {
        public int BuildingId { get; set; }
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
