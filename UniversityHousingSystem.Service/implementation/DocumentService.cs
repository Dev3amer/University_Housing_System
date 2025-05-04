using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class DocumentService : IDocumentService
    {
        #region Fields
        private readonly IDocumentRepository _documentRepository;
        #endregion

        #region Constructor
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        #endregion

        #region Methods
        public async Task<ICollection<Document>> AddDocumentsAsync(ICollection<Document> studentDocuments)
        {
            var addedDocuments = new List<Document>();

            var transaction = _documentRepository.BeginTransaction();
            try
            {
                foreach (var document in studentDocuments)
                {
                    addedDocuments.Add(await _documentRepository.AddAsync(document));
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

            return addedDocuments;
        }
        #endregion
    }
}

