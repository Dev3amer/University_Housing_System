namespace UniversityHousingSystem.Core.Features.Notifications.Queries.Results
{
    public class GetAllStudentNotificationsResponse
    {
        public int NotificationId { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
    }
}
