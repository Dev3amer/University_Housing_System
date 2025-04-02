using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class CollegeDepartmentRepository : GenericRepositoryAsync<CollegeDepartment>, ICollegeDepartmentRepository
    {
        public CollegeDepartmentRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<CollegeDepartment> GetByIdAsync(byte id)
        {
            return await _context.Set<CollegeDepartment>().FindAsync(id);
        }
    }
}
