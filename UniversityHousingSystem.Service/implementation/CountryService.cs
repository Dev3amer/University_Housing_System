using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class CountryService : ICountryService
    {
        #region Fields
        private readonly ICountryRepository _countryRepository;
        #endregion

        #region Contructors
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _countryRepository.GetTableNoTracking()
                .Include(v => v.Governorates)
                .ToListAsync();
        }


        #endregion
    }
}
