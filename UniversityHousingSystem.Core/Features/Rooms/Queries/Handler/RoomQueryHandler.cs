using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Rooms.Queries.Handler
{
    public class RoomQueryHandler : ResponseHandler,
        IRequestHandler<GetAllRoomsQuery, Response<List<GetAllRoomsResponse>>>,
        IRequestHandler<GetFreeRoomsQuery, Response<List<FreeRoomResponse>>>,
        IRequestHandler<GetRoomByIdQuery, Response<RoomResponse>>,
        IRequestHandler<GetRoomsPaginatedQuery, Response<PaginatedList<GetRoomsPaginatedResponse>>>


    {
        private readonly IRoomService _roomService;

        public RoomQueryHandler(IRoomService roomService) : base() // Ensure base constructor is called
        {
            _roomService = roomService;
        }

        public async Task<Response<List<GetAllRoomsResponse>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomService.GetAllAsync();

            //if (rooms == null || !rooms.Any())
            //    return NotFound<List<GetAllRoomsResponse>>("No rooms found."); //Return 200 OK instead of Error 404 if there are no rooms

            var response = rooms.Select(room => new GetAllRoomsResponse
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                Capacity = room.Capacity,
                Price = room.Price,
                BuildingId = room.BuildingId,
                OccupiedSpaces = room.Students?.Count ?? 0,
                PhotoUrls = room.RoomPhotos?.Select(p => p.PhotoPath).ToList() ?? new List<string>(),  // Retrieve photo URLs

            }).ToList();

            return Success(response);
        }



        public async Task<Response<List<FreeRoomResponse>>> Handle(GetFreeRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = _roomService.GetAllQueryable()
                .Where(r => r.Capacity - (r.Students != null ? r.Students.Count() : 0) > 0);

            if (request.MinAvailableSpace.HasValue)
            {
                rooms = rooms.Where(r => r.Capacity - (r.Students != null ? r.Students.Count() : 0) >= request.MinAvailableSpace.Value);
            }

            var result = await rooms.Select(r => new FreeRoomResponse
            {
                RoomId = r.RoomId,
                RoomNumber = r.RoomNumber,
                BuildingId = r.BuildingId,
                Capacity = r.Capacity,
                AvailableSpaces = r.Capacity - (r.Students != null ? r.Students.Count() : 0),
                Price = r.Price
            }).ToListAsync(cancellationToken);

            return Success(result);
        }

        public async Task<Response<RoomResponse>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomService.GetByIdAsync(request.Id);

            if (room == null)
                return NotFound<RoomResponse>($"Room with ID {request.Id} not found.");  // FIXED

            var response = new RoomResponse
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                BuildingId = room.BuildingId,
                Capacity = room.Capacity,
                Price = room.Price,
                OccupiedSpaces = room.Students?.Count ?? 0,
                PhotoUrls = room.RoomPhotos?.Select(p => p.PhotoPath).ToList() ?? new List<string>(),
                Students = room.Students?.Select(s => new StudentResponse
                {
                    StudentId = s.StudentId,
                    Name = s.FirstName,
                    Email = s.Email
                }).ToList() ?? new List<StudentResponse>()
            };

            return Success(response);  // FIXED
        }
        public async Task<Response<PaginatedList<GetRoomsPaginatedResponse>>> Handle(GetRoomsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var query = _roomService.GetAllQueryable();

            // Apply pagination
            var totalCount = await query.CountAsync(cancellationToken);
            var rooms = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(room => new GetRoomsPaginatedResponse
                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    Capacity = room.Capacity,
                    Price = room.Price,
                    BuildingId = room.BuildingId,
                    OccupiedSpaces = room.Students != null ? room.Students.Count : 0 // ✅ Fix for null-propagating issue
                })
                .ToListAsync(cancellationToken);

            var paginatedList = PaginatedList<GetRoomsPaginatedResponse>.Success(rooms, totalCount, request.Page, request.PageSize);

            return Success(paginatedList);
        }
    }
}





