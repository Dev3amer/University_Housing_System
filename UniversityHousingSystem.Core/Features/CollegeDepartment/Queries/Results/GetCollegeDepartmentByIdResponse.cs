using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetCollegeDepartmentByIdResponse
    {
        public int CollegeDepartmentId { get; set; }
        public string Name { get; set; } = default!;
        public int CollegeId { get; set; }
    }
}
