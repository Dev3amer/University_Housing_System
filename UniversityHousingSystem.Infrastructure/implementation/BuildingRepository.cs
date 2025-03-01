using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class BuildingRepository : GenericRepositoryAsync<Building>, IBuildingRepository
    {
        public BuildingRepository(AppDbContext context) : base(context)
        {

        }
    }
}
