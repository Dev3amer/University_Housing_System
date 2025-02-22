using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Village
    {

        public byte VillageID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int CityID { get; set; }

        // Navigation Property
        public City City { get; set; }
        public ICollection<Building> Buildings { get; set; }
        public ICollection<Student> Students { get; set; }


    }
}
