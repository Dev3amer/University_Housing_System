using MediatR;
using UniversityHousingSystem.Core.Features.Country.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Village.Queries.Models
{
    public class GetAllCountriesQuery : IRequest<Response<List<GetAllCountriesResponse>>>
    {
    }
}
