using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Visit
    {
        public int VisitID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string NationalID { get; set; }
        public DateTime VisitDate { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; }
    }
}
