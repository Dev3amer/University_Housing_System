using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetViolationTypeByIdResponse
    {
        public int ViolationTypeId { get; set; }
        public string ViolationTypeName { get; set; } = default!;
        public decimal? RequiredAmount { get; set; }
        public string ViolationLevel { get; set; } = default!;



    }
}
