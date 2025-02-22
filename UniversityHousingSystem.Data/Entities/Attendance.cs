using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public DateTime DataAndTime { get; set; }
        public string EntryType { get; set; }
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; }
    }
}
