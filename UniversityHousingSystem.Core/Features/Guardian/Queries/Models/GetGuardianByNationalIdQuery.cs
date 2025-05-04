using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetGuardianByNationalIdQuery : IRequest<Response<GetGuardianByIdResponse>>
    {
        public string NationalId { get; set; }

        public GetGuardianByNationalIdQuery(string nationalId)
        {
            NationalId = nationalId;
        }
    }
}
