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
        IRequestHandler<DeleteRoomCommand, Response<bool>> // ✅ Fixed Typo
    {
        private readonly IRoomService _roomService;
        private readonly IFileService _fileService;


        public RoomCommandHandler(IRoomService roomService, IFileService fileService)
        {
            _roomService = roomService;
            _fileService = fileService;
        }

        // ✅ Create Room Handler
        public async Task<Response<RoomResponse>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            // Check if a room with the same number already exists in the building
            var isRoomExists = await _roomService.IsExistInBuildingAsync(request.RoomNumber, request.BuildingId);
            if (isRoomExists)
                return BadRequest<RoomResponse>($"A room with number {request.RoomNumber} already exists in the building.");

            // Create the new room object
            var room = new Room
            {
                RoomNumber = request.RoomNumber,
                Capacity = request.Capacity,
                Price = Math.Round(request.Price, 2), // Ensure correct decimal precision
                BuildingId = request.BuildingId, // ✅ Only assign BuildingId, no need to assign Building object
                RoomPhotos = new List<RoomPhoto>()
            };

            // Handle room photos
            if (request.Photos != null && request.Photos.Any())
            {
                foreach (var photo in request.Photos)
                {
                    var photoPath = await _fileService.SaveFileAsync(photo, "Rooms");
                    if (string.IsNullOrEmpty(photoPath))
                        return BadRequest<RoomResponse>("Failed to save one or more room photos.");

                    room.RoomPhotos.Add(new RoomPhoto
                    {
                        PhotoPath = photoPath,
                        RoomId = room.RoomId // ✅ Explicitly assign RoomId to avoid EF Core issues
                    });
                }
            }

            try
            {
                // Save the room to the database
                var createdRoom = await _roomService.AddAsync(room);

                // Fetch saved room data (including photos) from the DB to ensure correct data
                var savedRoom = await _roomService.GetByIdAsync(createdRoom.RoomId);

                // Prepare response
                var response = new RoomResponse
                {
                    RoomId = savedRoom.RoomId,
                    RoomNumber = savedRoom.RoomNumber,
                    Capacity = savedRoom.Capacity,
                    Price = savedRoom.Price,
                    BuildingId = savedRoom.BuildingId,
                    PhotoUrls = savedRoom.RoomPhotos?.Select(p => p.PhotoPath).ToList() ?? new List<string>()
                };

                return Created(response, "Room created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest<RoomResponse>($"An error occurred while saving the room: {ex.Message} - {ex.InnerException?.Message}");
            }
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

            // ✅ Ensure RoomPhotos List is Initialized
            if (existingRoom.RoomPhotos == null)
                existingRoom.RoomPhotos = new List<RoomPhoto>();

            // ✅ Step 1: Save New Photos First (Before Deleting Old Ones)
            List<string> newPhotoPaths = new();
            if (request.Photos != null && request.Photos.Count > 0)
            {
                foreach (var photo in request.Photos)
                {
                    var filePath = await _fileService.SaveFileAsync(photo, "rooms");
                    newPhotoPaths.Add(filePath);
                }
            }

            // ✅ Step 2: Delete Old Photos (Only if New Ones Were Saved Successfully)
            foreach (var oldPhoto in existingRoom.RoomPhotos)
            {
                await _fileService.DeleteFileAsync(oldPhoto.PhotoPath);
            }

            // ✅ Step 3: Clear Old Photo Records and Add New Ones
            existingRoom.RoomPhotos.Clear();
            foreach (var newPhotoPath in newPhotoPaths)
            {
                existingRoom.RoomPhotos.Add(new RoomPhoto { RoomId = existingRoom.RoomId, PhotoPath = newPhotoPath });
            }

            // ✅ Step 4: Update Database
            var updatedRoom = await _roomService.UpdateAsync(existingRoom);

            // ✅ Return Updated Response
            var response = new RoomResponse
            {
                RoomId = updatedRoom.RoomId,
                RoomNumber = updatedRoom.RoomNumber,
                Capacity = updatedRoom.Capacity,
                Price = updatedRoom.Price,
                BuildingId = updatedRoom.BuildingId,
                PhotoUrls = updatedRoom.RoomPhotos.Select(p => p.PhotoPath).ToList()
            };

            return Success(response, "Room updated successfully.");
        }

        // ✅ Delete Room Handler (Now Inside Class)
        public async Task<Response<bool>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var searchedRoom = await _roomService.GetByIdAsync(request.RoomId);
            if (searchedRoom == null)
                return NotFound<bool>($"Room with ID {request.RoomId} not found.");

            if (searchedRoom.RoomPhotos?.Any() == true)
            {
                foreach (var photo in searchedRoom.RoomPhotos)
                {
                    await _fileService.DeleteFileAsync(photo.PhotoPath);
                }
            }

            await _roomService.DeleteAsync(searchedRoom);
            return Deleted<bool>($"Room with ID {request.RoomId} deleted successfully.");
        }





    }
}


