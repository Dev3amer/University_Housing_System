namespace UniversityHousingSystem.Data.Entities
{
    public class Response
    {
        public int ResponseId { get; set; }
        public DateTime ResponseAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public int StudentId { get; set; }
        public int QuestionnaireId { get; set; }

        // Navigation Properties
        public Student Student { get; set; } = new();
        public Questionnaire Questionnaire { get; set; } = new();
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}
