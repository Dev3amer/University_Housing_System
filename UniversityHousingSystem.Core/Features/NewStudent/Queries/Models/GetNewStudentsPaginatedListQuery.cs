using MediatR;
using UniversityHousingSystem.Core.Features.NewStudent.Queries.Results;
using UniversityHousingSystem.Core.Features.OldStudent.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.NewStudent.Queries.Models
{
    public class GetNewStudentsPaginatedListQuery : IRequest<PaginatedList<GetNewStudentsPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public EnStudentOrdering? StudentOrdering { get; set; }
        public GetNewStudentsPaginatedListQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
