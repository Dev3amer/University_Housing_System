using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class GuardianService : IGuardianService
    {
        #region Fields
        private readonly IGuardianRepository _guardianRepository;
        #endregion

        #region Contructors
        public GuardianService(IGuardianRepository guardianRepository)
        {
            _guardianRepository = guardianRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Guardian>> GetAllAsync()
        {
            return  _guardianRepository.GetTableNoTracking();
        }




        public async Task<Guardian?> GetAsync(int id)
        {
            return await _guardianRepository.GetByIdAsync(id);
        }
        public async Task<Guardian> CreateAsync(Guardian newGuardian)
        {
            return await _guardianRepository.AddAsync(newGuardian);
        }

        public async Task<Guardian> UpdateAsync(Guardian guardianToUpdate)
        {
            return await _guardianRepository.UpdateAsync(guardianToUpdate);
        }

        public async Task<bool> DeleteAsync(Guardian guardianToDelete)
        {
            await _guardianRepository.DeleteAsync(guardianToDelete);
            return true;
        }

        #endregion
    }
}
