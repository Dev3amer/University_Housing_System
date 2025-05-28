using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetViolationTypeByIdQuery : IRequest<Response<GetViolationTypeByIdResponse>>
    {
        public int ViolationTypeId { get; set; }

        public GetViolationTypeByIdQuery(int violationTypeId)
        {
            ViolationTypeId = violationTypeId;
        }
    }
}
