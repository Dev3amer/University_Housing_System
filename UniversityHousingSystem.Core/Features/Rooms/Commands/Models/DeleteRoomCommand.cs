using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class DeleteRoomCommand : IRequest<Response<bool>> // ✅ Corrected to return string response
    {
        public int RoomId { get; set; }

        public DeleteRoomCommand(int roomId)
        {
            RoomId = roomId;
        }
    }
}
