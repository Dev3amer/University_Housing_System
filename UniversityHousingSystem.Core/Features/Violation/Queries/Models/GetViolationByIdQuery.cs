using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetViolationByIdQuery : IRequest<Response<GetViolationByIdResponse>>
    {
        public int ViolationID { get; set; }
        public GetViolationByIdQuery(int violationud) => ViolationID = violationud;
    }
}
