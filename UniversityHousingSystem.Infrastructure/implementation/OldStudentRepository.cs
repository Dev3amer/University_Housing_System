using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class OldStudentRepository : GenericRepositoryAsync<OldStudent>, IOldStudentRepository
    {
        public OldStudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
