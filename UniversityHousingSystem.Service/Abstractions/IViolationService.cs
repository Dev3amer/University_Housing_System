using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IViolationService
    {
        Task<IEnumerable<Violation>> GetAllAsync();
        Task<Violation?> GetAsync(int id);
        Task<Violation> CreateAsync(Violation newViolation);
        Task<Violation> UpdateAsync(Violation violationToUpdate);
        Task<bool> DeleteAsync(Violation violationToDelete);
    }
}
