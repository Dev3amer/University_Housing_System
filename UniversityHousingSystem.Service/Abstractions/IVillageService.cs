using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IVillageService
    {
        Task<Village?> GetByIdAsync(int villageId);
        Task<IEnumerable<Village>> GetAllAsync();
    }
}
