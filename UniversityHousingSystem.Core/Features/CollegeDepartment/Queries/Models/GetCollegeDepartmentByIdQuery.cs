using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetCollegeDepartmentByIdQuery : IRequest<Response<GetCollegeDepartmentByIdResponse>>
    {
        public int CollegeDepartmentId { get; set; }
        public GetCollegeDepartmentByIdQuery(int collegeId) => CollegeDepartmentId = collegeId;
    }
}
