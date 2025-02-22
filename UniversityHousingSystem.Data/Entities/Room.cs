using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Room
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int DormitoryID { get; set; }
        public decimal Price { get; set; }

        // Navigation Property
        public Building Building { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
