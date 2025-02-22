using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class City
    {
        public byte CityID { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public byte GovernorateID { get; set; }

        // Navigation Property
        public Governorate Governorate { get; set; }
        public ICollection<Village> Villages { get; set; }
    }
}
