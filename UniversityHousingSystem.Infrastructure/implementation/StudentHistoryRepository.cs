using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class StudentHistoryRepository : GenericRepositoryAsync<StudentHistory>, IStudentHistoryRepository
    {
        public StudentHistoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
