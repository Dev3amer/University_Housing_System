using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IVillageService
    {
        Task<Village?> GetByIdAsync(int villageId);
        Task<IEnumerable<Village>> GetVillagesByCityIdAsync(int cityId);
        Task<Village?> GetAsync(int id);
    }
}
