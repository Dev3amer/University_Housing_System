using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Infrastructure.GenericBases;

namespace UniversityHousingSystem.Infrastructure.Repositories
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
