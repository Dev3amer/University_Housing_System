using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class IssueTypeRepository : GenericRepositoryAsync<IssueType>, IIssueTypeRepository
    {
        public IssueTypeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
