namespace UniversityHousingSystem.Data.Entities
{
    public class RoomPhoto
    {
        public int RoomPhotoId { get; set; }
        public int RoomId { get; set; }
        public string PhotoPath { get; set; } = default!;

        // Navigation Property
        public Room Room { get; set; } = default!;
    }
}
