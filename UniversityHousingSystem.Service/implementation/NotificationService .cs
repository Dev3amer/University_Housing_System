using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IStudentRepository _studentRepository;

        public NotificationService(INotificationRepository notificationRepository, IStudentRepository studentRepository)
        {
            _notificationRepository = notificationRepository;
            _studentRepository = studentRepository;
        }

        public async Task CreateNotificationToOneStudentAsync(int studentId, string title, string content)
        {
            var notification = new Notification
            {
                Title = title,
                Content = content,
                Date = DateTime.UtcNow,
                StudentsNotifications = new List<StudentsNotifications>
                {
                    new StudentsNotifications
                    {
                        StudentId = studentId,
                        IsRead = false
                    }
                }
            };

            await _notificationRepository.AddAsync(notification);
            await _notificationRepository.SaveChangesAsync();
        }
        public async Task SendToAllStudentsAsync(string title, string content)
        {
            var allStudentIds = await _studentRepository
                .GetTableNoTracking().Include(s => s.Application)
                .Where(s => s.Application.FinalStatus == EnStatus.Accepted)
                .Select(s => s.StudentId)
                .ToListAsync();

            var notification = new Notification
            {
                Title = title,
                Content = content,
                Date = DateTime.UtcNow,
                StudentsNotifications = allStudentIds
                    .Select(id => new StudentsNotifications
                    {
                        StudentId = id,
                        IsRead = false
                    })
                    .ToList()
            };

            await _notificationRepository.AddAsync(notification);
            await _notificationRepository.SaveChangesAsync();
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _notificationRepository.GetTableNoTracking()
                .Where(n => n.StudentsNotifications.Any(sn => sn.StudentId == userId && !sn.IsRead))
                .CountAsync();
        }

        public Task<List<Notification>> GetUserNotificationsAsync(int userId, int page = 1, int pageSize = 10)
        {
            return _notificationRepository.GetTableNoTracking()
                .Where(n => n.StudentsNotifications.Any(sn => sn.StudentId == userId))
                .OrderByDescending(n => n.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task MarkAllAsReadAsync(int userId)
        {
            var notifications = await _notificationRepository.GetTableAsTracking()
                                .Where(n => n.StudentsNotifications.Any(sn => sn.StudentId == userId && !sn.IsRead))
                                .ToListAsync();

            foreach (var notification in notifications)
            {
                foreach (var studentNotification in notification.StudentsNotifications
                             .Where(sn => sn.StudentId == userId && !sn.IsRead))
                {
                    studentNotification.IsRead = true;
                }
            }

            await _notificationRepository.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int notificationId, string userId)
        {
            var notification = await _notificationRepository.GetTableAsTracking()
            .Where(n => n.NotificationId == notificationId)
            .FirstOrDefaultAsync();

            if (notification == null)
                return;

            var studentNotification = notification.StudentsNotifications
                .FirstOrDefault(sn => sn.StudentId.ToString() == userId && !sn.IsRead);

            if (studentNotification != null)
            {
                studentNotification.IsRead = true;
                await _notificationRepository.SaveChangesAsync();
            }
        }
    }
}
