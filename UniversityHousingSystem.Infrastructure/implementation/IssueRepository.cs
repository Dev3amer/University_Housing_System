using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class IssueRepository : GenericRepositoryAsync<Issue>, IIssueRepository
    {
        public IssueRepository(AppDbContext context) : base(context)
        {

        }
    }
}
