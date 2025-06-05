using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class RegistrationPeriodRepository : GenericRepositoryAsync<RegistrationPeriod>, IRegistrationPeriodRepository
    {
        public RegistrationPeriodRepository(AppDbContext context) : base(context)
        {

        }
    }
}
