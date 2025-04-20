using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IHighSchoolService
    {
        Task<IEnumerable<HighSchool>> GetAllAsync();
        Task<HighSchool?> GetAsync(int id);
        Task<HighSchool> CreateAsync(HighSchool newHighSchool);
        Task<HighSchool> UpdateAsync(HighSchool highSchoolToUpdate);
        Task<bool> DeleteAsync(HighSchool highSchoolToDelete);
    }
}
