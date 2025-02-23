namespace UniversityHousingSystem.Data.Entities
{
    public class Village
    {
        public byte VillageId { get; set; }
        public string NameEn { get; set; } = default!;
        public string NameAr { get; set; } = default!;

        // Foreign Keys
        public int CityId { get; set; }

        // Navigation Property
        public ICollection<Building>? Buildings { get; set; }
        public City City { get; set; } = new();
        public ICollection<Student>? Students { get; set; }

    }
}
