using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class ViolationRepository : GenericRepositoryAsync<Violation>, IViolationRepository
    {
        public ViolationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
