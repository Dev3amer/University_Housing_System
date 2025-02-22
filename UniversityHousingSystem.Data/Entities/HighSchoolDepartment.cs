using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class HighSchoolDepartment
    {
        public int HighSchoolDepartmentID { get; set; }
        public string Name { get; set; }
        public int HighSchoolId { get; set; }

        // Navigation Property
        public HighSchool HighSchool { get; set; }
    }
}
