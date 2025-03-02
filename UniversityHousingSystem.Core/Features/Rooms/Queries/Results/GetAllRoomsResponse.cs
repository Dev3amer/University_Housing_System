namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class GetAllRoomsResponse
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = default!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int BuildingId { get; set; }
        public int OccupiedSpaces { get; set; }  // Number of students in the room
        public int FreeSpaces => Capacity - OccupiedSpaces; // Calculated field
    }
}
