using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Issue
    {

        public int IssueID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Response { get; set; }
        public int IssueTypeId { get; set; }
        public int StudentId { get; set; }
        public int EmployeeId { get; set; }

        // Navigation Properties
        public IssueType IssueType { get; set; }
        public Student Student { get; set; }
        public Employee Employee { get; set; }
    }
}
