using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class RoomRepository : GenericRepositoryAsync<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {

        }
    }
}
