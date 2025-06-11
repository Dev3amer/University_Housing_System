using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.GenericBases;
using UniversityHousingSystem.Infrastructure.Repositories;

namespace UniversityHousingSystem.Infrastructure.implementation
{
    public class NotificationRepository : GenericRepositoryAsync<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {

        }
    }
}
