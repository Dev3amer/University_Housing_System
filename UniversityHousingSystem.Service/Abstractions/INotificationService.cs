using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface INotificationService
    {
        Task CreateNotificationToOneStudentAsync(int studentId, string title, string content);
        Task<List<Notification>> GetUserNotificationsAsync(int userId, int page = 1, int pageSize = 10);
        Task<int> GetUnreadCountAsync(int userId);
        Task MarkAsReadAsync(int notificationId, string userId);
        Task MarkAllAsReadAsync(int userId);
        Task SendToAllStudentsAsync(string title, string content);
    }
}
