using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {

        }
    }
}
