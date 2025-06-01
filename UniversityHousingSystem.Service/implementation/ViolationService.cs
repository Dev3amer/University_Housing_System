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
        private readonly IViolationTypeRepository _violationTypeRepository;
        private readonly IStudentHistoryRepository _studentHistoryRepository;

        #endregion

        #region Constructors
        public ViolationService(IViolationRepository violationRepository, IViolationTypeRepository violationTypeRepository, IStudentHistoryRepository studentHistoryRepository)
        {
            _violationRepository = violationRepository;
            _violationTypeRepository = violationTypeRepository;
            _studentHistoryRepository = studentHistoryRepository;
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

        //public async Task<Violation> CreateAsync(Violation Violation)
        //{
        //    //return await _violationRepository.AddAsync(newViolation);
        //    var VType = await _violationTypeRepository.GetByIdAsync(Violation.ViolationTypeId);
        //    if (VType == null)
        //        throw new ArgumentException("Invalid Violationtype. Violationtype does not exist.");

        //    Violation.ViolationType = VType;
        //    return await _violationRepository.AddAsync(Violation);
        //}

        public async Task<Violation> CreateAsync(Violation violation)
        {
            // Validate violation type exists
            var violationType = await _violationTypeRepository.GetByIdAsync(violation.ViolationTypeId);
            if (violationType == null)
                throw new ArgumentException("Invalid violation type");

            // Find active student history
            var activeHistory = await _studentHistoryRepository.GetTableNoTracking()
                .FirstOrDefaultAsync(h => h.StudentId == violation.StudentHistoryId && h.To == null);

            if (activeHistory == null)
                throw new InvalidOperationException("No active housing history found for student");

            // Clear student history navigation property only
            violation.StudentHistory = null;

            // Set the correct history ID
            violation.StudentHistoryId = activeHistory.StudentHistoryId;

            // Keep the violation type assignment
            violation.ViolationType = violationType;

            return await _violationRepository.AddAsync(violation);
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
