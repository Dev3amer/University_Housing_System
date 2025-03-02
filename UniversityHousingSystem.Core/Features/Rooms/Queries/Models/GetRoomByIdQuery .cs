using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Models
{
    public class GetRoomByIdQuery : IRequest<Response<RoomResponse>>
    {
        public int Id { get; set; }
        public GetRoomByIdQuery(int id) => Id = id;
    }
}
