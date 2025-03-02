using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;
using UniversityHousingSystem.Service.Implementation;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Handler
{
    public class RoomCommandHandler : ResponseHandler,
        IRequestHandler<CreateRoomCommand, Response<RoomResponse>>,
        IRequestHandler<UpdateRoomCommand, Response<RoomResponse>>,
        IRequestHandler<DeleteRoomCommand, Response<string>> // ✅ Fixed Typo
    {
        private readonly IRoomService _roomService;

        public RoomCommandHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // ✅ Create Room Handler
        public async Task<Response<RoomResponse>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var isRoomExists = await _roomService.IsExistInBuildingAsync(request.RoomNumber, request.BuildingId);
            if (isRoomExists)
                return BadRequest<RoomResponse>($"A room with number {request.RoomNumber} already exists in the building.");

            var room = new Room
            {
                RoomNumber = request.RoomNumber,
                Capacity = request.Capacity,
                Price = request.Price,
                BuildingId = request.BuildingId
            };

            var createdRoom = await _roomService.AddAsync(room);

            var response = new RoomResponse
            {
                RoomId = createdRoom.RoomId,
                RoomNumber = createdRoom.RoomNumber,
                Capacity = createdRoom.Capacity,
                Price = createdRoom.Price,
                BuildingId = createdRoom.BuildingId
            };

            return Created(response, "Room created successfully.");
        }

        // ✅ Update Room Handler
        public async Task<Response<RoomResponse>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var existingRoom = await _roomService.GetByIdAsync(request.RoomId);
            if (existingRoom == null)
                return NotFound<RoomResponse>($"Room with ID {request.RoomId} not found.");

            var isDuplicateRoom = await _roomService.IsExistInBuildingAsync(request.RoomNumber, request.BuildingId);
            if (isDuplicateRoom && existingRoom.RoomNumber != request.RoomNumber)
                return BadRequest<RoomResponse>($"A room with number {request.RoomNumber} already exists in the building.");

            existingRoom.RoomNumber = request.RoomNumber;
            existingRoom.Capacity = request.Capacity;
            existingRoom.Price = request.Price;
            existingRoom.BuildingId = request.BuildingId;

            var updatedRoom = await _roomService.UpdateAsync(existingRoom);

            var response = new RoomResponse
            {
                RoomId = updatedRoom.RoomId,
                RoomNumber = updatedRoom.RoomNumber,
                Capacity = updatedRoom.Capacity,
                Price = updatedRoom.Price,
                BuildingId = updatedRoom.BuildingId
            };

            return Success(response, "Room updated successfully.");
        }

        // ✅ Delete Room Handler (Now Inside Class)
        public async Task<Response<string>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var existingRoom = await _roomService.GetByIdAsync(request.RoomId);
            if (existingRoom == null)
                return NotFound<string>($"Room with ID {request.RoomId} not found.");

            var isDeleted = await _roomService.DeleteAsync(existingRoom);
            if (!isDeleted)
                return BadRequest<string>("Failed to delete the room. Please try again.");

            return Success("Room deleted successfully.");
        }
    }
}


