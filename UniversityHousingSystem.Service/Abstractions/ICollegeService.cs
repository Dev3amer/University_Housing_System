using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface ICollegeService
    {
        Task<IEnumerable<College>> GetAllAsync();
      //  IQueryable<Guardian> GetAllQueryable(string? search, EnEventOrdering? EventOrderingEnum);
        Task<College?> GetAsync(int id);
        Task<College> CreateAsync(College newEvent);
        Task<College> UpdateAsync(College eventToUpdate);
        Task<bool> DeleteAsync(College eventToDelete);

    }
}
