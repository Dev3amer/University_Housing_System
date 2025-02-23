namespace UniversityHousingSystem.Data.Entities
{
    public class Questionnaire
    {
        public int QuestionnaireId { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ForYear { get; set; }

        //Foreign Keys
        public int CreatedBy { get; set; }

        // Navigation Property
        public Employee Employee { get; set; } = new();
        public ICollection<Question>? Questions { get; set; }
        public ICollection<Response>? Responses { get; set; }
    }
}
