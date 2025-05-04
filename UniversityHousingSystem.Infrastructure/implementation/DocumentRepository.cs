using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class DocumentRepository : GenericRepositoryAsync<Document>, IDocumentRepository
    {
        public DocumentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
