namespace UniversityHousingSystem.Core.Features.Governorate.Queries.Results
{
    public class GetAllCitiesByGovernorateIdResponse
    {
        public int CityId { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
    }
}
