using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Response
    {
        public int ResponseID { get; set; }
        public DateTime ResponseAt { get; set; }
        public int UserID { get; set; }
        public int QuestionnaireId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
