using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class NewStudent
    {
        public int NewStudentID { get; set; }
        public decimal HighSchoolPercentage { get; set; }
        public bool IsOutsideSchool { get; set; }
        public int HighSchoolId { get; set; }

        // Navigation Property
        public Student Student { get; set; }
        public HighSchool HighSchool { get; set; }
    }
}
