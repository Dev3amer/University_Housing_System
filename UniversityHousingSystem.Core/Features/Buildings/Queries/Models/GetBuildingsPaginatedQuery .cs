using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetBuildingsPaginatedQuery : IRequest<PaginatedList<GetBuildingsPaginatedResponse>>
    {
        public string? Search { get; set; }
        public EnBuildingType? BuildingType { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
