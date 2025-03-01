using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetBuildingByIdQuery : IRequest<Response<GetBuildingByIdResponse>>
    {
        public int BuildingId { get; set; }

        public GetBuildingByIdQuery(int buildingId)
        {
            BuildingId = buildingId;
        }
    }
}
