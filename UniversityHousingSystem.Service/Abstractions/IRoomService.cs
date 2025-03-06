using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IRoomService
    {
        Task<ICollection<Room>> GetAllAsync();
        IQueryable<Room> GetAllQueryable();
        Task<Room> GetByIdAsync(int id);
        Task<Room> AddAsync(Room room);
        Task<Room> UpdateAsync(Room room); // New Update Method
        Task<bool> IsExistAsync(int id);
        Task<bool> IsExistInBuildingAsync(string roomNumber, int buildingId);
        Task<bool> IsExistByRoomIdInBuildingAsync(int roomId, int buildingId);
        Task DeleteAsync(Room room); // Make sure this method signature is correct
        Task<int> CountRoomsInBuilding(int buildingId);
        decimal CalculateRoomsPrice(IEnumerable<Room> roomsList);
        Task DeleteRoomPhotosAsync(ICollection<RoomPhoto> roomPhotos); // Add this method signature

    }

}
