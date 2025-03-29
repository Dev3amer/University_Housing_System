using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IGuardianService
    {
        Task<IEnumerable<Guardian>> GetAllAsync();
      //  IQueryable<Guardian> GetAllQueryable(string? search, EnEventOrdering? EventOrderingEnum);
        Task<Guardian?> GetAsync(int id);
        Task<Guardian> CreateAsync(Guardian newEvent);
        Task<Guardian> UpdateAsync(Guardian eventToUpdate);
        Task<bool> DeleteAsync(Guardian eventToDelete);
    }
}
