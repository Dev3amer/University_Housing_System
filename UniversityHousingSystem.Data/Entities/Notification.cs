namespace UniversityHousingSystem.Data.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public bool IsRead { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
