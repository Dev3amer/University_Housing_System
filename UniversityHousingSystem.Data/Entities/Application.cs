using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public DateTime SubmitDate { get; set; }
        public string AIValidationStatus { get; set; }
        public string FinalStatus { get; set; }
        public string AdminNotes { get; set; }

        // Navigation Property
        public Student Student { get; set; }
    }
}
