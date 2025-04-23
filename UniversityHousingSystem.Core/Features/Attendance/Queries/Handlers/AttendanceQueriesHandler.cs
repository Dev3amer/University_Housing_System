using MediatR;
using UniversityHousingSystem.Core.Features.Attendance.Queries.Models;
using UniversityHousingSystem.Core.Features.Attendance.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Attendance.Queries.Handlers
{

    public class AttendanceQueriesHandler : ResponseHandler,
        IRequestHandler<GetStudentsAttendancePaginatedListQuery, PaginatedList<GetStudentsAttendancePaginatedListResponse>>
    {
        #region Fields
        private readonly IAttendanceService _attendanceService;
        #endregion

        #region Constructor
        public AttendanceQueriesHandler(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        #endregion
        public async Task<PaginatedList<GetStudentsAttendancePaginatedListResponse>> Handle(GetStudentsAttendancePaginatedListQuery request, CancellationToken cancellationToken)
        {
            var StudentsAttendanceListQueryable = _attendanceService.GetAllQueryable(request.dateTime, request.StudentNationalId);

            var paginatedList = await StudentsAttendanceListQueryable.Select(a => new GetStudentsAttendancePaginatedListResponse
            {
                AttendanceId = a.AttendanceId,
                DateAndTime = a.DateAndTime,
                EntryType = a.EntryType,
                Phone = a.Student.Phone,
                StudentId = a.StudentId,
                StudentName = $"{a.Student.FirstName} {a.Student.SecondName} {a.Student.ThirdName} {a.Student.FourthName}",
                StudentNationalId = a.Student.NationalId
            }).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }
    }
}
