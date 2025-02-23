namespace UniversityHousingSystem.Data.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }

        // Foreign Keys
        public int? OptionId { get; set; }
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }

        // Navigation Properties
        public Response Response { get; set; } = new();
        public Question Question { get; set; } = new();
        public Option? Option { get; set; }
    }
}
