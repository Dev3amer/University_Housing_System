namespace UniversityHousingSystem.Data.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string ThirdName { get; set; } = default!;
        public string FourthName { get; set; } = default!;

        // Foreign Keys
        public string? UserId { get; set; }

        // Navigation Property
        public ApplicationUser? User { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Issue>? Issues { get; set; }
        public ICollection<Questionnaire>? Questionnaires { get; set; }
    }
}
