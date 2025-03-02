using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class VillageRepository : GenericRepositoryAsync<Village>, IVillageRepository
    {
        public VillageRepository(AppDbContext context) : base(context)
        {

        }
    }
}
