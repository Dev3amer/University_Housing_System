using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class CollegeRepository : GenericRepositoryAsync<College>, ICollegeRepository
    {
        public CollegeRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<College?> GetByIdAsync(int id)
        {
            return await _context.Colleges
                .Include(c => c.Departments) // Ensure related entities are loaded
                .Include(s=>s.Students).FirstOrDefaultAsync(c => c.CollegeId == id);
        }


    }
}
