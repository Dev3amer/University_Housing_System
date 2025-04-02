using Microsoft.EntityFrameworkCore;
using Stripe;
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
        private readonly IFileService _fileService; // Add _fileService
        private readonly IRoomPhotoRepository _roomPhotoRepository;
        private readonly IBuildingRepository _buildingRepository;

        #endregion

        #region Constructors
        public RoomService(IRoomRepository roomRepository, IBuildingRepository buildingRepository, IFileService fileService, IRoomPhotoRepository roomPhotoRepository)
        {
            _roomRepository = roomRepository;
            _buildingRepository = buildingRepository;
            _fileService = fileService;
            _roomPhotoRepository = roomPhotoRepository;
        }
        #endregion

        #region Methods

        // ✅ Get all rooms
        public async Task<ICollection<Room>> GetAllAsync()
        {
            return await _roomRepository.GetTableNoTracking()
                .Include(r => r.RoomPhotos) // Include the RoomPhotos navigation property
                .ToListAsync();
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
                .Include(r => r.RoomPhotos) // ✅ Include photos
                .Include(r => r.Students)   // (Optional) Include students if needed
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
        // ✅ Delete a room
        //public async Task DeleteAsync(Room room)
        //{
        //    try
        //    {
        //        var roomFromDb = await _roomRepository.GetTableNoTracking()
        //            .Include(r => r.RoomPhotos)
        //            .FirstOrDefaultAsync(r => r.RoomId == room.RoomId);

        //        if (roomFromDb == null)
        //        {
        //            Console.WriteLine("Room not found.");
        //            return; // Room not found, nothing to delete
        //        }

        //        // Delete room photos if they exist
        //        if (roomFromDb.RoomPhotos != null && roomFromDb.RoomPhotos.Any())
        //        {
        //            foreach (var photo in roomFromDb.RoomPhotos)
        //            {
        //                await _fileService.DeleteFileAsync(photo.PhotoPath); // Call without assigning
        //                Console.WriteLine($"Deleted photo: {photo.PhotoPath}");
        //            }
        //        }

        //        // Disassociate students from the room
        //        foreach (var student in roomFromDb.Students)
        //        {
        //            student.RoomId = null; // Remove the association with the room
        //        }

        //        // Commit changes to disassociate students and delete photos
        //        await _roomRepository.SaveChangesAsync(); // No need to capture the result

        //        // Delete the room from the repository
        //        await _roomRepository.DeleteAsync(roomFromDb);
        //        Console.WriteLine($"Room {roomFromDb.RoomId} deleted.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error deleting room: {ex.Message}");
        //    }
        //}





        // ✅ Count rooms in a specific building
        public async Task DeleteAsync(Room room)
        {
            try
            {
                var roomFromDb = await _roomRepository.GetTableAsTracking() // ✅ REMOVE NoTracking to enable tracking
                    .Include(r => r.RoomPhotos)
                    .Include(r => r.Students)
                    .FirstOrDefaultAsync(r => r.RoomId == room.RoomId);

                if (roomFromDb == null)
                {
                    Console.WriteLine("Room not found.");
                    return; // Room not found, nothing to delete
                }

                // ✅ Disassociate students from the room
                if (roomFromDb.Students != null && roomFromDb.Students.Any())
                {
                    foreach (var student in roomFromDb.Students)
                    {
                        student.RoomId = null; // Remove room assignment
                    }
                }

                await _roomRepository.SaveChangesAsync(); // ✅ Save changes first

                // ✅ Now delete the tracked entity
                await _roomRepository.DeleteAsync(roomFromDb);
                await _roomRepository.SaveChangesAsync(); // ✅ Commit deletion

                Console.WriteLine($"Room {roomFromDb.RoomId} deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting room: {ex.Message}");
            }
        }

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

        //////////3/6

        public async Task DeleteRoomPhotosAsync(ICollection<RoomPhoto> roomPhotos)
        {
            foreach (var photo in roomPhotos)
            {
                // Assuming you have a repository for RoomPhotos
                await _roomPhotoRepository.DeleteAsync(photo);  // Ensure you have a RoomPhoto repository for DB operations
            }

            // Save changes to persist the deletions in the database
            await _roomPhotoRepository.SaveChangesAsync();
        }

        #endregion
    }

}

