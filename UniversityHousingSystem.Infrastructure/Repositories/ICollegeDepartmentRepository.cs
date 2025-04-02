using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.GenericBases;

namespace UniversityHousingSystem.Infrastructure.Repositories
{
    public interface ICollegeDepartmentRepository : IGenericRepositoryAsync<CollegeDepartment>
    {
        Task<CollegeDepartment> GetByIdAsync(byte id);

    }
}
