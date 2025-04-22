using MediatR;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Attendance.Commands.Models
{
    public class CreateStudentAttendance : IRequest<Response<bool>>
    {
        public string QRText { get; set; } = default!;
        public EnAttendanceType Type { get; set; } = default!;
    }
}
