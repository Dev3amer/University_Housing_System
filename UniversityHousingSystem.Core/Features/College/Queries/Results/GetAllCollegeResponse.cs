using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetAllCollegeResponse
    {
        public int CollegeId { get; set; }
        public string Name { get; set; } = default!;

       
    }
}
