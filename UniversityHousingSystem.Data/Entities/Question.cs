using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; } = default!;
        public EnQuestionType Type { get; set; }
        public int IsRequired { get; set; }

        // Foreign Keys
        public int QuestionnaireId { get; set; }

        // Navigation Properties
        public Questionnaire Questionnaire { get; set; } = new();
        public ICollection<Option>? Options { get; set; }
        public Answer? Answer { get; set; }
    }
}
