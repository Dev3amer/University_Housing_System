using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class StudentHistoryService : IStudentHistoryService
    {
        #region Fields
        private readonly IStudentHistoryRepository _studentHistoryRepository;
        #endregion

        #region Contructors
        public StudentHistoryService(IStudentHistoryRepository studentHistoryRepository)
        {
            _studentHistoryRepository = studentHistoryRepository;
            
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<StudentHistory>> GetAllAsync()
        {
            return _studentHistoryRepository.GetTableNoTracking()
                .Include(h=>h.Violations).ThenInclude(v => v.ViolationType)
        .ToList();
        }




        public async Task<StudentHistory?> GetAsync(int id)
        {
            return await _studentHistoryRepository.GetTableNoTracking().Include(s=>s.Student)
                .Include(h => h.Violations)
                    .ThenInclude(v => v.ViolationType)
                .FirstOrDefaultAsync(h => h.StudentHistoryId == id);
        }


        public async Task<StudentHistory> CreateAsync(StudentHistory newStudentHistory)
        {
            return await _studentHistoryRepository.AddAsync(newStudentHistory);
        }
       

        public async Task<StudentHistory> UpdateAsync(StudentHistory StudentHistoryToUpdate)
        {
            return await _studentHistoryRepository.UpdateAsync(StudentHistoryToUpdate);
        }

        public async Task<bool> DeleteAsync(StudentHistory StudentHistoryToDelete)
        {
            await _studentHistoryRepository.DeleteAsync(StudentHistoryToDelete);
            return true;
        }
       


        #endregion
    }
}
