using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface INewStudentService
    {
        Task<IEnumerable<NewStudent>> GetAllAsync();
        IQueryable<NewStudent> GetAllQueryable(string? search, EnStudentOrdering? studentOrderingEnum);
        Task<NewStudent?> GetAsync(int id);
        Task<NewStudent> CreateAsync(NewStudent newStudent);
        Task<NewStudent> UpdateAsync(NewStudent newStudentToUpdate);
        Task<bool> DeleteAsync(NewStudent newStudentToDelete);
    }
}
