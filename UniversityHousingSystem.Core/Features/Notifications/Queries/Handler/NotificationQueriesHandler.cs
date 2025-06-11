using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Notifications.Queries.Models;
using UniversityHousingSystem.Core.Features.Notifications.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Notifications.Queries.Handler
{
    public class NotificationQueriesHandler : ResponseHandler,
        IRequestHandler<GetAllStudentNotificationsQuery, Response<List<GetAllStudentNotificationsResponse>>>
    {
        private readonly INotificationService _notificationService;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        public NotificationQueriesHandler(INotificationService notificationService, ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager)
        {
            _notificationService = notificationService;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        public async Task<Response<List<GetAllStudentNotificationsResponse>>> Handle(GetAllStudentNotificationsQuery request, CancellationToken cancellationToken)
        {
            var currentStudent = _userManager.Users
                .Where(u => u.Id == _currentUserService.GetUserId())
                .Select(u => u.Student)
                .FirstOrDefault();

            if (currentStudent is null)
                return Unauthorized<List<GetAllStudentNotificationsResponse>>(SharedResourcesKeys.UnAuthorized);

            var notifications = await _notificationService.GetUserNotificationsAsync(currentStudent.StudentId, request.Page, request.PageSize);

            var response = notifications.Select(n => new GetAllStudentNotificationsResponse
            {
                NotificationId = n.NotificationId,
                Title = n.Title,
                Content = n.Content,
                Date = n.Date,
                IsRead = n.StudentsNotifications.Any(sn => sn.StudentId == currentStudent.StudentId && sn.IsRead)
            }).ToList();

            return Success(response, new { Page = request.Page, PageSize = request.PageSize });
        }
    }
}
