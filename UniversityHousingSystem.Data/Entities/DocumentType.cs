namespace UniversityHousingSystem.Data.Entities
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; } = default!;

        // Navigation Properties
        public ICollection<Document>? Documents { get; set; }
    }
}
