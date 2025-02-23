namespace UniversityHousingSystem.Data.Entities
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Text { get; set; } = default!;

        // Foreign Keys
        public int QuestionId { get; set; }

        // Navigation Property
        public Question Question { get; set; } = new();
        public ICollection<Answer>? Answers { get; set; }
    }
}
