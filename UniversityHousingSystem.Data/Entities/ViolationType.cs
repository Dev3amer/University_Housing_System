using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class ViolationType
    {
        public int ViolationTypeID { get; set; }
        public string Description { get; set; }
        public bool? ViolationLevel { get; set; }
        public decimal? RequiredAmount { get; set; }

        // Navigation Property
        public ICollection<Violation> Violations { get; set; }
    }
}
