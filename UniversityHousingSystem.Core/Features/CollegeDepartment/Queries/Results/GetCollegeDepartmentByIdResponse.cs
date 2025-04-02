using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetCollegeDepartmentByIdResponse
    {
        public byte CollegeDepartmentId { get; set; }
        public string Name { get; set; } = default!;
        public int CollegeId { get; set; }

        //  public List<string>? Departments { get; set; }
        // public List<string>? Students { get; set; }



    }
}
