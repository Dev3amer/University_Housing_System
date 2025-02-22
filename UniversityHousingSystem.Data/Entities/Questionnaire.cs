using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Questionnaire
    {
        public int QuestionnaireID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ForYear { get; set; }

        // Navigation Property
        public Employee Employee { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
