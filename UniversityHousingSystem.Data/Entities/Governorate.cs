using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Governorate
    {
        public byte GovernorateID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int CountryId { get; set; }

        // Navigation Property
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
