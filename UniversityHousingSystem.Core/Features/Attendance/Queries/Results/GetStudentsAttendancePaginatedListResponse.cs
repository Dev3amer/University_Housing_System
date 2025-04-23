using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Attendance.Queries.Results
{
    public class GetStudentsAttendancePaginatedListResponse
    {
        public int AttendanceId { get; set; }
        public DateTime DateAndTime { get; set; }
        public EnAttendanceType EntryType { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = default!;
        public string StudentNationalId { get; set; } = default!;
        public string Phone { get; set; } = default!;
    }
}
