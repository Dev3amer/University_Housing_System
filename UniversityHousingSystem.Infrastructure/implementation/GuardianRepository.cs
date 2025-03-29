using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class GuardianRepository : GenericRepositoryAsync<Guardian>, IGuardianRepository
    {
        public GuardianRepository(AppDbContext context) : base(context)
        {

        }
    }
}
