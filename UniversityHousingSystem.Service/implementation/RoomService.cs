using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.implementation;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{

    public class RoomService : IRoomService
    {
        #region Fields
        private readonly IRoomRepository _roomRepository;
        private readonly IBuildingRepository _buildingRepository;
        #endregion

        #region Constructors
        public RoomService(IRoomRepository roomRepository, IBuildingRepository buildingRepository)
        {
            _roomRepository = roomRepository;
            _buildingRepository = buildingRepository;
        }
        #endregion

        #region Methods

        // ✅ Get all rooms
        public async Task<ICollection<Room>> GetAllAsync()
        {
            return await _roomRepository.GetTableNoTracking().ToListAsync();
        }

        // ✅ Get all rooms as IQueryable
        public IQueryable<Room> GetAllQueryable()
        {
            return _roomRepository.GetTableNoTracking();
        }

        // ✅ Get a room by ID
        public async Task<Room> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(r => r.RoomId == id);

            if (room == null)
                throw new KeyNotFoundException($"Room with ID {id} not found.");

            return room;
        }

        // ✅ Create a new room
        public async Task<Room> AddAsync(Room room)
        {
            // Fetch the building to ensure it exists and assign it to the room
            var building = await _buildingRepository.GetByIdAsync(room.BuildingId);

            if (building == null)
                throw new ArgumentException("Invalid BuildingId. Building does not exist.");

            room.Building = building; // ✅ Explicitly assign the building

            return await _roomRepository.AddAsync(room);
        }


        // ✅ Update an existing room
        public async Task<Room> UpdateAsync(Room room)
        {
            return await _roomRepository.UpdateAsync(room);
        }

        // ✅ Check if a room exists by ID
        public async Task<bool> IsExistAsync(int id)
        {
            return await _roomRepository.GetTableNoTracking()
                .AnyAsync(r => r.RoomId == id);
        }

        // ✅ Check if a room exists in a specific building
        public async Task<bool> IsExistInBuildingAsync(string roomNumber, int buildingId)
        {
            return await _roomRepository.GetTableNoTracking()
                .AnyAsync(r => r.RoomNumber == roomNumber && r.BuildingId == buildingId);
        }

        // ✅ Check if a room ID exists in a specific building
        public async Task<bool> IsExistByRoomIdInBuildingAsync(int roomId, int buildingId)
        {
            return await _roomRepository.GetTableNoTracking()
                .AnyAsync(r => r.RoomId == roomId && r.BuildingId == buildingId);
        }

        // ✅ Delete a room
        public async Task<bool> DeleteAsync(Room room)
        {
            try
            {
                await _roomRepository.DeleteAsync(room);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ✅ Count rooms in a specific building
        public async Task<int> CountRoomsInBuilding(int buildingId)
        {
            return await _roomRepository.GetTableNoTracking()
                .CountAsync(r => r.BuildingId == buildingId);
        }

        // ✅ Calculate total price of rooms
        public decimal CalculateRoomsPrice(IEnumerable<Room> roomsList)
        {
            return roomsList.Sum(r => r.Price);
        }

        #endregion
    }

}

