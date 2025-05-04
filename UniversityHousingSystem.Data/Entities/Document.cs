namespace UniversityHousingSystem.Data.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Path { get; set; } = default!;
        public EnDocumentType DocumentType { get; set; }

        //Foreign Keys
        public int StudentId { get; set; }

        // Navigation Properties
        public Student Student { get; set; } = new();
    }
    public enum EnDocumentType
    {
        NationalIdImage = 1,
        GuardianNationalIdImage = 2,
        PersonalImage = 3,
        waterBill = 4,
        ResidenceApplication = 5,
    }
}
