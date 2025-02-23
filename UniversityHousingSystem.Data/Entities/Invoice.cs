using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Data.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int ForMonth { get; set; } = DateTime.UtcNow.Month;
        public decimal RequiredAmount { get; set; }
        public DateTime DueDate { get; set; }
        public EnPaymentStatus Status { get; set; } = EnPaymentStatus.Pending;

        //Foreign Keys
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; } = new();
        public Payment? Payment { get; set; }
    }
}
