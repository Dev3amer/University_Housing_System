using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetCollegeByIdResponse
    {
        public int CollegeId { get; set; }
        public string Name { get; set; } = default!;
        public List<string>? Departments { get; set; }
        public List<string>? Students { get; set; }


    }
}
