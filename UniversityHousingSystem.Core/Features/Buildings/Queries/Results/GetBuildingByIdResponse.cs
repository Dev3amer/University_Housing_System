namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetBuildingByIdResponse
    {
        public int BuildingId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Address { get; set; } = default!;
        public string? MapSearchText { get; set; }
        public string Type { get; set; } = default!;
        public string VillageName { get; set; } = default!;
        public string Gender { get; set; } = default!;
    }
}
