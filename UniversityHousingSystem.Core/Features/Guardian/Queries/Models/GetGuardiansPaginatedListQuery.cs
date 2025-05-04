using MediatR;
using UniversityHousingSystem.Core.Features.Guardian.Queries.Results;
using UniversityHousingSystem.Core.Pagination;

namespace UniversityHousingSystem.Core.Features.Guardian.Queries.Models
{
    public class GetGuardiansPaginatedListQuery : IRequest<PaginatedList<GetGuardiansPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetGuardiansPaginatedListQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
