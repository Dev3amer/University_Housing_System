using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Country
    {
        public int CountryID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        // Navigation Property
        public ICollection<Governorate> Governorates { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
