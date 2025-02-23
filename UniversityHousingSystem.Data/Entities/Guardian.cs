namespace UniversityHousingSystem.Data.Entities
{
    public class Guardian
    {
        public int GuardianId { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;
        public string Job { get; set; } = default!;
        public string NationalId { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string GuardianRelation { get; set; } = default!;

        // Navigation Property
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
