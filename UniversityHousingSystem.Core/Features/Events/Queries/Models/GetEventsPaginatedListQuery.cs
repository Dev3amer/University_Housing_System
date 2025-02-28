using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetEventsPaginatedListQuery : IRequest<PaginatedList<GetEventsPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public EnEventOrdering? EventOrdering { get; set; }
        public GetEventsPaginatedListQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
