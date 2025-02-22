using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public int IsRequired { get; set; }
        public int QuestionnaireId { get; set; }

        // Navigation Properties
        public Questionnaire Questionnaire { get; set; }
        public ICollection<Option> Options { get; set; }
        public Answer Answer { get; set; }
    }
}
