using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IBuildingService
    {
        Task<IEnumerable<Building>> GetAllAsync();
        Task<IEnumerable<Building>> GetBuildingsByTypeAsync(EnBuildingType type);
        IQueryable<Building> GetAllQueryable(string? search, EnBuildingType? buildingOrderingEnum);
        Task<Building?> GetAsync(int id);
        Task<Building> CreateAsync(Building newBuilding);
        Task<Building> UpdateAsync(Building buildingToUpdate);
        Task<bool> DeleteAsync(Building buildingToDelete);
        Task<int> GetBuildingsAvailableSpaces(EnGender gender);
    }
}
