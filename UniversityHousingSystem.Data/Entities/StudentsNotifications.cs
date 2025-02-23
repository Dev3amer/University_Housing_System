namespace UniversityHousingSystem.Data.Entities
{
    public class StudentsNotifications
    {
        public int StudentsNotificationsId { get; set; }

        //Foreign Keys
        public int StudentId { get; set; }
        public int NotificationId { get; set; }

        //Navigation Properties
        public Student Student { get; set; } = new();
        public Notification Notification { get; set; } = new();
    }
}
