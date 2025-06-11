using MediatR;
using UniversityHousingSystem.Core.Features.Notifications.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Notifications.Queries.Models
{
    public class GetAllStudentNotificationsQuery : IRequest<Response<List<GetAllStudentNotificationsResponse>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
