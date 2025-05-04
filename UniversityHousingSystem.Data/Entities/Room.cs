namespace UniversityHousingSystem.Data.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = default!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }


        //Foreign Keys
        public int BuildingId { get; set; }

        // Navigation Property
        public Building Building { get; set; } = default!;
        public ICollection<Student>? Students { get; set; }
        public ICollection<RoomPhoto>? RoomPhotos { get; set; }

    }
}
