using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.GenericBases;

namespace UniversityHousingSystem.Infrastructure.Repositories
{
    public interface IRoomPhotoRepository : IGenericRepositoryAsync<RoomPhoto>
    {
        Task DeleteAsync(RoomPhoto roomPhoto);
        Task SaveChangesAsync();
    }
}
