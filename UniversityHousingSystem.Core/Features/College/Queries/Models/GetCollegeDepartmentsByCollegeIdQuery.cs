using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.College.Queries.Models
{
    public class GetCollegeDepartmentsByCollegeIdQuery : IRequest<Response<List<GetAllCollegeDepartmentResponse>>>
    {
        public int CollegeId { get; set; }
    }
}
