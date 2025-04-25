using MediatR;
using UniversityHousingSystem.Core.Features.Employees.Queries.Results;
using UniversityHousingSystem.Core.Pagination;

namespace UniversityHousingSystem.Core.Features.Employees.Queries.Models
{
    public class GetEmployeesPaginatedListQuery : IRequest<PaginatedList<GetEmployeesPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public GetEmployeesPaginatedListQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
