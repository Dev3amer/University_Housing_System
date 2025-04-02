using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetCollegeDepartmentByIdQuery : IRequest<Response<GetCollegeDepartmentByIdResponse>>
    {
        public byte CollegeDepartmentId { get; set; }
        public GetCollegeDepartmentByIdQuery(byte collegeId) => CollegeDepartmentId = collegeId;
    }
}
