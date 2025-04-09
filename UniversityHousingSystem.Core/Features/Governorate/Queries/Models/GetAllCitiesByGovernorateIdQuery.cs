using MediatR;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Governorate.Queries.Models
{
    public class GetAllCitiesByGovernorateIdQuery : IRequest<Response<List<GetAllCitiesByGovernorateIdResponse>>>
    {
        public int GovernorateId { get; set; }
    }
}
