using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{
    public class RegistrationPeriodService : IRegistrationPeriodService
    {
        #region Fields
        private readonly IRegistrationPeriodRepository _registrationPeriodRepo;
        #endregion

        #region Constructors
        public RegistrationPeriodService(IRegistrationPeriodRepository registrationPeriodRepo)
        {
            _registrationPeriodRepo = registrationPeriodRepo;
        }


        #endregion

        #region Methods
        public async Task<RegistrationPeriod> CreateAsync(RegistrationPeriod newPeriod)
        {
            return await _registrationPeriodRepo.AddAsync(newPeriod);
        }

        public async Task<bool> DeleteAsync(RegistrationPeriod PeriodToDelete)
        {
            _registrationPeriodRepo.BeginTransaction();
            try
            {
                await _registrationPeriodRepo.DeleteAsync(PeriodToDelete);
                _registrationPeriodRepo.Commit();
                return true;
            }
            catch
            {
                _registrationPeriodRepo.RollBack();
                return false;
            }
        }

        public async Task<IEnumerable<RegistrationPeriod>> GetAllAsync()
        {
            return await _registrationPeriodRepo.GetTableNoTracking().ToListAsync();
        }

        public async Task<RegistrationPeriod?> GetAsync(int id)
        {
            return await _registrationPeriodRepo.GetTableNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<RegistrationPeriod> GetCurrentRegistrationPeriodAsync()
        {
            return await _registrationPeriodRepo.GetTableNoTracking()
                .OrderByDescending(p => p.From)
                .FirstOrDefaultAsync();
        }

        public async Task<RegistrationPeriod> UpdateAsync(RegistrationPeriod PeriodToUpdate)
        {
            return await _registrationPeriodRepo.UpdateAsync(PeriodToUpdate);
        }
        #endregion
    }
}
