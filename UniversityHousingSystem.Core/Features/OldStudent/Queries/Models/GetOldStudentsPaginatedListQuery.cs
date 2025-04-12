using MediatR;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.OldStudent.Queries.Models
{
    public class GetOldStudentsPaginatedListQuery : IRequest<PaginatedList<GetOldStudentsPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public EnStudentOrdering? StudentOrdering { get; set; }
        public GetOldStudentsPaginatedListQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
