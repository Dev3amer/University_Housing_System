using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class HighSchool
    {
        public int HighSchoolID { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<HighSchoolDepartment> Departments { get; set; }
        public ICollection<NewStudent> NewStudents { get; set; }
    }
}
