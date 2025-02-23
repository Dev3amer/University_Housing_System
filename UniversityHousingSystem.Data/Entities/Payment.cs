namespace UniversityHousingSystem.Data.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public EnPaymentMethod PaymentMethod { get; set; }

        //Foreign Keys
        public int? InvoiceId { get; set; }

        // Navigation Property
        public Invoice? Invoice { get; set; }
    }
}
