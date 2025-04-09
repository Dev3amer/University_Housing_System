using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IGovernorateService
    {
        Task<IEnumerable<Governorate>> GetAllByCountryIdAsync(int countryId);
    }
}
