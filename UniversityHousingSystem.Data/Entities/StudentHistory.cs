using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class StudentHistory
    {
        public int StudentHistoryID { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int StudentId { get; set; }
        public int ViolationID { get; set; }

        // Navigation Properties
        public Student Student { get; set; }
        public ICollection<Violation> Violations { get; set; }
    }
}
