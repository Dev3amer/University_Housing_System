using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }

        // Navigation Property
        public Employee Employee { get; set; }

    }
}
