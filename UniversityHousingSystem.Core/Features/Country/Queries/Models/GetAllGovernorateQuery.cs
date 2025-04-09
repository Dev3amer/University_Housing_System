using MediatR;
using UniversityHousingSystem.Core.Features.Country.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Country.Queries.Models
{
    public class GetAllGovernoratesByCountryIdQuery : IRequest<Response<List<GetAllGovernoratesByCountryIdResponse>>>
    {
        public int CountryId { get; set; }
    }
}
