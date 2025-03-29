using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Features.Governorate.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Governorate.Queries.Models
{
    public class GetAllGovernorateQuery : IRequest<Response<List<GetAllGovernorateResponse>>>
    {
        public int CountryId { get; set; }

    }
}
