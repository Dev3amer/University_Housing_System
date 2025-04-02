using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface ICollegeDepartmentService
    {
        Task<IEnumerable<CollegeDepartment>> GetAllAsync();
      //  IQueryable<Guardian> GetAllQueryable(string? search, EnEventOrdering? EventOrderingEnum);
        Task<CollegeDepartment?> GetAsync(byte id);
        Task<CollegeDepartment> CreateAsync(CollegeDepartment newEvent);
        Task<CollegeDepartment> UpdateAsync(CollegeDepartment eventToUpdate);
        Task<bool> DeleteAsync(CollegeDepartment eventToDelete);

        Task<CollegeDepartment?> GetLastCollegeDepartmentAsync();
    }
}
