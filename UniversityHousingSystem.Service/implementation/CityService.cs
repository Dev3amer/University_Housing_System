using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class CityService : ICityService
    {
        #region Fields
        private readonly ICityRepository _cityRepository;
        #endregion

        #region Contructors
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _cityRepository.GetTableNoTracking()
                .Include(v=>v.Villages)
                .ToListAsync();
        }


        #endregion
    }
}
