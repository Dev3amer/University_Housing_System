using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<IEnumerable<Event>> GetComingEventsAsync();
        IQueryable<Event> GetAllQueryable(string? search, EnEventOrdering? EventOrderingEnum);
        Task<Event?> GetAsync(int id);
        Task<Event> CreateAsync(Event newEvent);
        Task<Event> UpdateAsync(Event eventToUpdate);
        Task<bool> DeleteAsync(Event eventToDelete);
    }
}
