using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.implementation;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{
    public class ViolationService : IViolationService
    {
        #region Fields
        private readonly IViolationRepository _violationRepository;
        #endregion

        #region Constructors
        public ViolationService(IViolationRepository violationRepository)
        {
            _violationRepository = violationRepository;             
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<Violation>> GetAllAsync()
        {
            return await _violationRepository.GetTableNoTracking().ToListAsync();
               
        }

       

       public async Task<Violation> GetAsync(int id)
        {
            return await _violationRepository.GetTableNoTracking()
               .Include(i => i.StudentHistory)
               .Include(i => i.ViolationType)
               .FirstOrDefaultAsync(i => i.ViolationId == id);
        }

        public async Task<Violation> CreateAsync(Violation newViolation)
        {
            return await _violationRepository.AddAsync(newViolation);
        }

        public async Task<Violation> UpdateAsync(Violation ViolationToUpdate)
        {
            return await _violationRepository.UpdateAsync(ViolationToUpdate);
        }
        public async Task<bool> DeleteAsync(Violation violationToDelete)
        {
            await _violationRepository.DeleteAsync(violationToDelete);
            return true;
        }

        #endregion
    }
}
