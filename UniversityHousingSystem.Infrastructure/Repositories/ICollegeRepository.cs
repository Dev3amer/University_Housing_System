using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.GenericBases;

namespace UniversityHousingSystem.Infrastructure.Repositories
{
    public interface ICollegeRepository : IGenericRepositoryAsync<College>
    {
        Task<College?> GetByIdAsync(int id);

    }

}
