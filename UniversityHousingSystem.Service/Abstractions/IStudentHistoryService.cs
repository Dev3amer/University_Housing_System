using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IStudentHistoryService
    {
        Task<IEnumerable<StudentHistory>> GetAllAsync();
        Task<StudentHistory?> GetAsync(int id);
        Task<StudentHistory> CreateAsync(StudentHistory newStudentHistory);
        Task<StudentHistory> UpdateAsync(StudentHistory studentHistoryToUpdate);
        Task<bool> DeleteAsync(StudentHistory studentHistoryToDelete);
    }
}
