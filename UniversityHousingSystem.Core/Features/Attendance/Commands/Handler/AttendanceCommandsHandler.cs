using MediatR;
using UniversityHousingSystem.Core.Features.Attendance.Commands.Models;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Attendance.Commands.Handler
{
    public class AttendanceCommandsHandler : ResponseHandler,
        IRequestHandler<CreateStudentAttendance, Response<bool>>
    {
        #region Fields
        private readonly IAttendanceService _attendanceService;
        private readonly IStudentService _studentService;
        #endregion

        #region Constructor
        public AttendanceCommandsHandler(IAttendanceService attendanceService, IStudentService studentService)
        {
            _attendanceService = attendanceService;
            _studentService = studentService;
        }
        #endregion

        public async Task<Response<bool>> Handle(CreateStudentAttendance request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByQrTextAsync(request.QRText);
            if (student == null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Student)));

            var newAttendance = new Data.Entities.Attendance()
            {
                DateAndTime = DateTime.UtcNow,
                EntryType = request.Type,
                StudentId = student.StudentId
            };

            var result = await _attendanceService.CreateAsync(newAttendance);

            if (result is not null)
                return Created(true, SharedResourcesKeys.Success);
            else
                return UnprocessableEntity<bool>(SharedResourcesKeys.TryAgain);
        }
    }
}
