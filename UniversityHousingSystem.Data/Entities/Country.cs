namespace UniversityHousingSystem.Data.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string NameEn { get; set; } = default!;
        public string NameAr { get; set; } = default!;

        // Navigation Property
        public ICollection<Governorate>? Governorates { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
