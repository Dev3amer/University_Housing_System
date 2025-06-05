namespace UniversityHousingSystem.Data.Entities
{
    public class StudentRegistrationCode
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string Code { get; set; } = default!;
        public decimal Amount { get; set; }
        //payment tracking
        public bool IsPaid { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }

        // Audit fields
        public DateTime CreatedAt { get; set; }
        public bool IsUsed { get; set; }

        public DateTime AllowedTime { get; set; }

        public Student? Student { get; set; }
    }
}
