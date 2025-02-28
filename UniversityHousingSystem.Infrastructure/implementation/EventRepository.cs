using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class EventRepository : GenericRepositoryAsync<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {

        }
    }
}
