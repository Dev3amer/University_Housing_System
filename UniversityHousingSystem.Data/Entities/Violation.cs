using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Violation
    {
        public int ViolationID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int ViolationTypeId { get; set; }
        public int StudentHistoryId { get; set; }

        // Navigation Properties
        public ViolationType ViolationType { get; set; }
        public StudentHistory StudentHistory { get; set; }
    }
}
