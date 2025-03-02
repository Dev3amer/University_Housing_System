namespace UniversityHousingSystem.Core.Features.Events.Queries.Results
{
    public class FreeRoomResponse
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int BuildingId { get; set; }
        public int Capacity { get; set; }

        public int AvailableSpaces { get; set; }
        public decimal Price { get; set; }
    }
}
