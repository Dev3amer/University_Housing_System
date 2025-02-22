using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Option
    {
        public int OptionID { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }

        // Navigation Property
        public Question Question { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
