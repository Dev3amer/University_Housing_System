using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public decimal RequiredAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }

        // Navigation Property
        public Student Student { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
