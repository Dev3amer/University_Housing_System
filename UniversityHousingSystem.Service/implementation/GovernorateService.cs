using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class GovernorateService : IGovernorateService
    {
        #region Fields
        private readonly IGovernorateRepository _governorateRepository;
        #endregion

        #region Contructors
        public GovernorateService(IGovernorateRepository governorateRepository)
        {
            _governorateRepository = governorateRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Governorate>> GetAllByCountryIdAsync(int countryId)
        {
            return await _governorateRepository
                .GetTableNoTracking()
                .Where(g => g.CountryId == countryId)
                .ToListAsync();
        }
        #endregion
    }
}
