using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetGuardianByIdQuery : IRequest<Response<GetGuardianByIdResponse>>
    {
        public int GuardianId { get; set; }

        public GetGuardianByIdQuery(int guardianId)
        {
            GuardianId = guardianId;
        }
    }
}
