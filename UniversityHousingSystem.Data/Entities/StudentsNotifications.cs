namespace UniversityHousingSystem.Data.Entities
{
    public class StudentsNotifications
    {
        //Pk & Foreign Keys
        public int StudentId { get; set; }
        public int NotificationId { get; set; }
        public bool IsRead { get; set; }

        //Navigation Properties
        public virtual Student Student { get; set; } = new();
        public virtual Notification Notification { get; set; } = new();
    }
}
