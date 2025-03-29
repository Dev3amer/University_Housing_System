using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IGovernorateService
    {
        Task<IEnumerable<Governorate>> GetAllAsync();
      //  IQueryable<Guardian> GetAllQueryable(string? search, EnEventOrdering? EventOrderingEnum);
       
    }
}
