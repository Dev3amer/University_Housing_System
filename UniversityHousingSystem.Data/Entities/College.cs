using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class College
    {
        public int CollegeID { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<CollegeDepartment> Departments { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
