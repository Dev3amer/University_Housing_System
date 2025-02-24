namespace UniversityHousingSystem.Data.Entities
{
    public class StudentsNotifications
    {
        //Pk & Foreign Keys
        public int StudentId { get; set; }
        public int NotificationId { get; set; }

        //Navigation Properties
        public Student Student { get; set; } = new();
        public Notification Notification { get; set; } = new();
    }
}
