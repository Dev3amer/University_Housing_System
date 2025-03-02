namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class RoomResponse
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int BuildingId { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public List<StudentResponse> Students { get; set; } = new();
        public int OccupiedSpaces { get; set; }  // Number of students in the room
        public int FreeSpaces => Capacity - OccupiedSpaces; // Calculated field
    }

    public class StudentResponse
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
