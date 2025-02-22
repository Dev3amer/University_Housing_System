using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class OldStudent
    {

        public int OldStudentID { get; set; }
        public string PreviousYearGrade { get; set; }
        public decimal GradePercentage { get; set; }
        public string PreviousYearHosting { get; set; }

        // Navigation Property
        public Student Student { get; set; }
    }
}
