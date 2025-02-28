namespace UniversityHousingSystem.Data.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string NameEn { get; set; } = default!;
        public string NameAr { get; set; } = default!;

        // Foreign Keys
        public int GovernorateId { get; set; }

        // Navigation Property
        public Governorate Governorate { get; set; } = default!;
        public ICollection<Village> Villages { get; set; } = new HashSet<Village>();
    }
}
