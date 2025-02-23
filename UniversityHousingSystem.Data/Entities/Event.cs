namespace UniversityHousingSystem.Data.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        // Foreign Key
        public int CreatedBy { get; set; }

        // Navigation Property
        public Employee Employee { get; set; } = new();

    }
}
