using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public DateTime DateAndTime { get; set; }
        public EnAttendanceType EntryType { get; set; }

        // Foreign Keys
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; } = new();
    }
}
