using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IRegistrationPeriodService
    {
        Task<IEnumerable<RegistrationPeriod>> GetAllAsync();
        Task<RegistrationPeriod> GetCurrentRegistrationPeriodAsync();
        //Task<IEnumerable<RegistrationPeriod>> GetBuildingsByTypeAsync(EnBuildingType type);
        //IQueryable<RegistrationPeriod> GetAllQueryable(string? search, EnBuildingType? buildingOrderingEnum);
        Task<RegistrationPeriod?> GetAsync(int id);
        Task<RegistrationPeriod> CreateAsync(RegistrationPeriod newPeriod);
        Task<RegistrationPeriod> UpdateAsync(RegistrationPeriod PeriodToUpdate);
        Task<bool> DeleteAsync(RegistrationPeriod PeriodToDelete);
    }
}
