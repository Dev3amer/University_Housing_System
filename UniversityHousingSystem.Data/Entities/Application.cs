using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public DateTime SubmitDate { get; set; } = DateTime.UtcNow;
        public EnStatus AIValidationStatus { get; set; } = EnStatus.Pending;
        public EnStatus FinalStatus { get; set; } = EnStatus.Pending;
        public string? AdminNotes { get; set; }

        // Navigation Property
        public Student Student { get; set; } = default!;
    }
}
