﻿using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class StudentRegistrationRepository : GenericRepositoryAsync<StudentRegistrationCode>, IStudentRegistrationRepository
    {
        public StudentRegistrationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
