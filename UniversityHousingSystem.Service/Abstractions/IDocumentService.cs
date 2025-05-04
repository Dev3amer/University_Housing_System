using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IDocumentService
    {
        public Task<ICollection<Document>> AddDocumentsAsync(ICollection<Document> studentDocuments);
    }
}

