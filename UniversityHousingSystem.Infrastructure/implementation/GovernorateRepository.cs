using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class GovernorateRepository : GenericRepositoryAsync<Governorate>, IGovernorateRepository
    {
        public GovernorateRepository(AppDbContext context) : base(context)
        {

        }
    }
}
