namespace UniversityHousingSystem.Data.Entities
{
    public class City
    {
        public byte CityId { get; set; }
        public string NameEn { get; set; } = default!;
        public string NameAr { get; set; } = default!;

        // Foreign Keys
        public byte GovernorateId { get; set; }

        // Navigation Property
        public Governorate Governorate { get; set; } = new();
        public ICollection<Village> Villages { get; set; } = new HashSet<Village>();
    }
}
