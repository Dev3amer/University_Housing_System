using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class NewStudentRepository : GenericRepositoryAsync<NewStudent>, INewStudentRepository
    {
        public NewStudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
