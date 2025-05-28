using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.implementation;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{
    public class ViolationTypeService : IViolationTypeService
    {
        #region Fields
        private readonly IViolationTypeRepository _violationTypeRepository;
        #endregion

        #region Constructors
        public ViolationTypeService(IViolationTypeRepository violationTypeRepository)
        {
            _violationTypeRepository = violationTypeRepository;             
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<ViolationType>> GetAllAsync()
        {
            return await _violationTypeRepository.GetTableNoTracking().ToListAsync();
               
        }

       

       public async Task<ViolationType> GetAsync(int id)
        {
            return await _violationTypeRepository.GetTableNoTracking()
               .Include(i => i.Violations)
               .FirstOrDefaultAsync(i => i.ViolationTypeId == id);
        }

        public async Task<ViolationType> CreateAsync(ViolationType newViolationType)
        {
            return await _violationTypeRepository.AddAsync(newViolationType);
        }

        public async Task<ViolationType> UpdateAsync(ViolationType ViolationTypeToUpdate)
        {
            return await _violationTypeRepository.UpdateAsync(ViolationTypeToUpdate);
        }
        public async Task<bool> DeleteAsync(ViolationType violationTypeToDelete)
        {
            await _violationTypeRepository.DeleteAsync(violationTypeToDelete);
            return true;
        }

        #endregion
    }
}
