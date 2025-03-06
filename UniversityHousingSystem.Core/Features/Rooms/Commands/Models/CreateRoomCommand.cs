using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Models
{
    public class CreateRoomCommand : IRequest<Response<RoomResponse>>
    {
        
            public string RoomNumber { get; set; } = default!;
            public int Capacity { get; set; }
            public decimal Price { get; set; }
            public int BuildingId { get; set; }
        public List<IFormFile>? Photos { get; set; } // ✅ Allow multiple photos


    }
}
