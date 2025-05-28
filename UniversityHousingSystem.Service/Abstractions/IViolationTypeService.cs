using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IViolationTypeService
    {
        Task<IEnumerable<ViolationType>> GetAllAsync();
        Task<ViolationType?> GetAsync(int id);
        Task<ViolationType> CreateAsync(ViolationType newViolationType);
        Task<ViolationType> UpdateAsync(ViolationType violationTypeToUpdate);
        Task<bool> DeleteAsync(ViolationType violationTypeToDelete);
    }
}
