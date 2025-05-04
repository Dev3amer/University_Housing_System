using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;

namespace MovieReservationSystem.Infrastructure.Seeding
{
    public class RoomsSeeder
    {
        private readonly AppDbContext _context;
        public RoomsSeeder(AppDbContext context)
        {
            _context = context;
        }
        public async Task SeedRoomsAsync()
        {
            var rooms = new List<Room>();

            // Building 1: Rooms A1 to A67
            for (int i = 1; i <= 67; i++)
            {
                rooms.Add(new Room
                {
                    RoomNumber = $"A{i}",
                    Capacity = 4,
                    Price = 350,
                    BuildingId = 1,
                    RoomPhotos = new List<RoomPhoto>
                    {
                        new RoomPhoto { PhotoPath = "/uploads/Rooms/defaultRoom.jpg" }
                    }
                });
            }

            // Building 2: Rooms B1 to B67
            for (int i = 1; i <= 67; i++)
            {
                rooms.Add(new Room
                {
                    RoomNumber = $"B{i}",
                    Capacity = 4,
                    Price = 350,
                    BuildingId = 2,
                    RoomPhotos = new List<RoomPhoto>
                    {
                        new RoomPhoto { PhotoPath = "/uploads/Rooms/defaultRoom.jpg" }
                    }
                });
            }

            // Building 3: Rooms C1 to C74
            for (int i = 1; i <= 74; i++)
            {
                rooms.Add(new Room
                {
                    RoomNumber = $"C{i}",
                    Capacity = 4,
                    Price = 350,
                    BuildingId = 3,
                    RoomPhotos = new List<RoomPhoto>
                    {
                        new RoomPhoto { PhotoPath = "/uploads/Rooms/defaultRoom.jpg" }
                    }
                });
            }

            // Building 4: Rooms D1 to D74
            for (int i = 1; i <= 74; i++)
            {
                rooms.Add(new Room
                {
                    RoomNumber = $"D{i}",
                    Capacity = 4,
                    Price = 350,
                    BuildingId = 4,
                    RoomPhotos = new List<RoomPhoto>
                    {
                        new RoomPhoto { PhotoPath = "/uploads/Rooms/defaultRoom.jpg" }
                    }
                });
            }
            if (!_context.Rooms.Any())
            {
                await _context.Rooms.AddRangeAsync(rooms);
                await _context.SaveChangesAsync();
            }
        }
    }
}
