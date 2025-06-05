namespace UniversityHousingSystem.Core.Features.StudentRegistration.Queries.Results
{
    public class StudentRegistrationCodeResult
    {
        public string Email { get; set; } = default!;
        public string Code { get; set; } = default!;
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
