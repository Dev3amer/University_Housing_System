using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllAsync();
       
    }
}
