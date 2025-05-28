using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class ViolationTypeRepository : GenericRepositoryAsync<ViolationType>, IViolationTypeRepository
    {
        public ViolationTypeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
