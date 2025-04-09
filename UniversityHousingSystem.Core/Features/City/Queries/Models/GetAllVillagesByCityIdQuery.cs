using MediatR;
using UniversityHousingSystem.Core.Features.City.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.City.Queries.Models
{
    public class GetAllVillagesByCityIdQuery : IRequest<Response<List<GetAllVillagesByCityIdResponse>>>
    {
        public int CityId { get; set; }
    }
}
