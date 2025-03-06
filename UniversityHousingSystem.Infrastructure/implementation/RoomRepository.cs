using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class RoomRepository : GenericRepositoryAsync<Room>, IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Room> UpdateAsync(Room room)
        {
            var existingRoom = await _context.Rooms
                .Include(r => r.RoomPhotos) // ✅ Include photos so EF tracks them
                .FirstOrDefaultAsync(r => r.RoomId == room.RoomId);

            if (existingRoom == null)
                throw new KeyNotFoundException($"Room with ID {room.RoomId} not found.");

            // ✅ Step 1: Update room properties
            existingRoom.RoomNumber = room.RoomNumber;
            existingRoom.Capacity = room.Capacity;
            existingRoom.Price = room.Price;
            existingRoom.BuildingId = room.BuildingId;

            // ✅ Step 2: Handle Photos
            if (room.RoomPhotos != null)
            {
                // Remove old photos
                _context.RoomPhotos.RemoveRange(existingRoom.RoomPhotos);

                // Add new photos
                foreach (var newPhoto in room.RoomPhotos)
                {
                    existingRoom.RoomPhotos.Add(new RoomPhoto
                    {
                        RoomId = room.RoomId,
                        PhotoPath = newPhoto.PhotoPath
                    });
                }
            }

            // ✅ Step 3: Save Changes
            _context.Rooms.Update(existingRoom);
            await _context.SaveChangesAsync();

            return existingRoom;
        }
        public async Task<List<Student>> GetStudentsByRoomIdAsync(int roomId)
        {
            return await _context.Students
                .Where(s => s.RoomId == roomId)
                .ToListAsync();
        }
        public async Task DeleteAsync(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
