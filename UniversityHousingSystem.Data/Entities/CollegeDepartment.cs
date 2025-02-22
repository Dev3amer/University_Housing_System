using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UniversityHousingSystem.Data.Entities
{
    public class CollegeDepartment
    {
        public byte CollegeDepartmentID { get; set; }
        public string Name { get; set; }
        public int CollegeID { get; set; }

        // Navigation Property
        public College College { get; set; }
    }
}
