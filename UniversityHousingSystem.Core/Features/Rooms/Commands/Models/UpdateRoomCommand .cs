using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class UpdateRoomCommand : IRequest<Response<RoomResponse>>
    {
        public int RoomId { get; set; }  // 🔹 Identifies the room to be updated
        public string RoomNumber { get; set; } = default!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int BuildingId { get; set; }
    }
}
