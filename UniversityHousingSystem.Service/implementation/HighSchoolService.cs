using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class HighSchoolService : IHighSchoolService
    {
        #region Fields
        private readonly IHighSchoolRepository _highSchoolRepository;
        #endregion

        #region Contructors
        public HighSchoolService(IHighSchoolRepository highSchoolRepository)
        {
            _highSchoolRepository = highSchoolRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<HighSchool>> GetAllAsync()
        {
            return await _highSchoolRepository.GetTableNoTracking()
                .ToListAsync();
        }
        public async Task<HighSchool?> GetAsync(int id)
        {
            return await _highSchoolRepository
                .GetTableNoTracking()
                .FirstOrDefaultAsync(e => e.HighSchoolId == id);
        }
        public async Task<HighSchool> CreateAsync(HighSchool newHighSchool)
        {
            newHighSchool.Name = newHighSchool.Name.Trim();

            return await _highSchoolRepository.AddAsync(newHighSchool);
        }
        public async Task<HighSchool> UpdateAsync(HighSchool highSchoolToUpdate)
        {
            highSchoolToUpdate.Name = highSchoolToUpdate.Name.Trim();

            return await _highSchoolRepository.UpdateAsync(highSchoolToUpdate);
        }
        public async Task<bool> DeleteAsync(HighSchool highSchoolToDelete)
        {
            _highSchoolRepository.BeginTransaction();
            try
            {
                await _highSchoolRepository.DeleteAsync(highSchoolToDelete);
                _highSchoolRepository.Commit();
                return true;
            }
            catch
            {
                _highSchoolRepository.RollBack();
                return false;
            }
        }

        #endregion
    }
}
