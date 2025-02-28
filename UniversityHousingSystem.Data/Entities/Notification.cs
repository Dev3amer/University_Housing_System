namespace UniversityHousingSystem.Data.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public virtual ICollection<StudentsNotifications> StudentsNotifications { get; set; } = new HashSet<StudentsNotifications>();
    }
}
