using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int OptionId { get; set; }

        // Navigation Properties
        public Response Response { get; set; }
        public Question Question { get; set; }
        public Option Option { get; set; }
    }
}
