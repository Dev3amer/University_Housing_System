using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class IssueType
    {
        public int IssueTypeID { get; set; }
        public string TypeName { get; set; }

        // Navigation Property
        public ICollection<Issue> Issues { get; set; }
    }
}
