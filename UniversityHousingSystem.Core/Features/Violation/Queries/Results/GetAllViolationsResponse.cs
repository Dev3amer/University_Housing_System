using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetAllViolationsResponse
    {
        public int ViolationId { get; set; }
        public DateTime ViolationDate { get; set; }

        public int ViolationTypeId { get; set; }
       // public int StudentHistoryId { get; set; }

    }
}
