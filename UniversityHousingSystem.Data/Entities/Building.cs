using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Building
    {
        public int DormitoryID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public int VillageID { get; set; }
        public string AddressInDetails { get; set; }
        public string MapSearchText { get; set; }
        public string Type { get; set; }

        // Navigation Property
        public Village Village { get; set; }
        public ICollection<Room> Rooms { get; set; }

    }
}
