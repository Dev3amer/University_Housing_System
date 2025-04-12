using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{
    public class VillageService : IVillageService
    {
        #region Fields
        private readonly IVillageRepository _villageRepository;
        #endregion

        #region Constructor
        public VillageService(IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Village>> GetVillagesByCityIdAsync(int cityId)
        {
            return await _villageRepository.GetTableNoTracking()
                .Where(v => v.CityId == cityId)
                .Include(v => v.City)
                //.Include(v => v.Buildings)
                .ToListAsync();
        }

        public async Task<Village?> GetByIdAsync(int villageId)
        {
            return await _villageRepository.GetTableNoTracking()
                .Include(v => v.City)
                //.Include(v => v.Buildings)
                .FirstOrDefaultAsync(v => v.VillageId == villageId);
        }

        public async Task<Village?> GetAsync(int id)
        {
            var village = await _villageRepository.GetByIdAsync(id);
            return village;
        }
        #endregion
    }
}
