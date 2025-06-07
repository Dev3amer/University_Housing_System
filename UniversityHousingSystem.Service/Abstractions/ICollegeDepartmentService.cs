using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface ICollegeDepartmentService
    {
        Task<IEnumerable<CollegeDepartment>> GetAllAsync();
        //  IQueryable<Guardian> GetAllQueryable(string? search, EnEventOrdering? EventOrderingEnum);
        Task<CollegeDepartment?> GetAsync(int id);
        Task<CollegeDepartment> CreateAsync(CollegeDepartment newEvent);
        Task<CollegeDepartment> UpdateAsync(CollegeDepartment eventToUpdate);
        Task<bool> DeleteAsync(CollegeDepartment eventToDelete);

        Task<CollegeDepartment?> GetLastCollegeDepartmentAsync();
        Task<IEnumerable<CollegeDepartment>> GetAllDepartmentsByCollegeId(int collegeId);
    }
}
