using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string UserID { get; set; }

        // Navigation Property
        public User User { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Issue> Issues { get; set; }
        public ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
