namespace UniversityHousingSystem.Data.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Path { get; set; } = default!;

        //Foreign Keys
        public int StudentId { get; set; }
        public int DocTypeId { get; set; }

        // Navigation Properties
        public Student Student { get; set; } = new();
        public DocumentType DocumentType { get; set; } = new();
    }
}
