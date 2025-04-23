using MediatR;
using UniversityHousingSystem.Core.Features.Attendance.Queries.Results;
using UniversityHousingSystem.Core.Pagination;

namespace UniversityHousingSystem.Core.Features.Attendance.Queries.Models
{
    public class GetStudentsAttendancePaginatedListQuery : IRequest<PaginatedList<GetStudentsAttendancePaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? dateTime { get; set; }
        public string? StudentNationalId { get; set; }
        public GetStudentsAttendancePaginatedListQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
