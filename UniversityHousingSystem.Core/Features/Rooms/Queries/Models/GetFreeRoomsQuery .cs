using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetFreeRoomsQuery : IRequest<Response<List<FreeRoomResponse>>>
    {
        public int? MinAvailableSpace { get; set; } // Optional filter for minimum free space
    }
}
