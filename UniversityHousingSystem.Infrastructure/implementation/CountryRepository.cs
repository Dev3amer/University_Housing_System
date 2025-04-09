using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class CountryRepository : GenericRepositoryAsync<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
