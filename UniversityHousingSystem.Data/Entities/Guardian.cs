using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Guardian
    {
        public int GuardianID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string Job { get; set; }
        public int NationalID { get; set; }
        public string Phone { get; set; }
        public string GuardianRelation { get; set; }

        // Navigation Property
        public ICollection<Student> Students { get; set; }
    }
}
