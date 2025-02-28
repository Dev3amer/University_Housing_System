namespace UniversityHousingSystem.Data.Entities
{
    public class Governorate
    {
        public int GovernorateId { get; set; }
        public string NameEn { get; set; } = default!;
        public string NameAr { get; set; } = default!;

        // Foreign Keys
        public int CountryId { get; set; }

        // Navigation Property
        public Country Country { get; set; } = default!;
        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
