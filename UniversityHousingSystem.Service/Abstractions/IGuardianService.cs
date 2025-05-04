using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IGuardianService
    {
        Task<IEnumerable<Guardian>> GetAllAsync();
        IQueryable<Guardian> GetAllQueryable();
        Task<Guardian?> GetAsync(int id);
        Task<Guardian?> GetByNationalIdAsync(string NationalId);
        Task<Guardian> CreateAsync(Guardian newEvent);
        Task<Guardian> UpdateAsync(Guardian eventToUpdate);
        Task<bool> DeleteAsync(Guardian eventToDelete);
    }
}
