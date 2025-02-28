using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class EventService : IEventService
    {
        #region Fields
        private readonly IEventRepository _eventRepository;
        #endregion

        #region Contructors
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _eventRepository.GetTableNoTracking()
                .Include(e => e.Employee)
                .ToListAsync();
        }
        public async Task<IEnumerable<Event>> GetComingEventsAsync()
        {
            return await _eventRepository.GetTableNoTracking()
                .Where(e => e.Date > DateTime.UtcNow)
                .Include(e => e.Employee)
                .ToListAsync();
        }
        public IQueryable<Event> GetAllQueryable(string? search, EnEventOrdering? eventOrderingEnum)
        {

            var queryableList = _eventRepository.GetTableNoTracking()
               .Include(e => e.Employee)
               .AsQueryable();

            if (search != null)
            {
                queryableList = queryableList.Where(m => m.Title.Contains(search));
            }

            switch (eventOrderingEnum)
            {
                case EnEventOrdering.Title:
                    queryableList = queryableList.OrderBy(e => e.Title);
                    break;
                case EnEventOrdering.Date:
                    queryableList = queryableList.OrderByDescending(e => e.Date);
                    break;
                default:
                    queryableList = queryableList.OrderBy(m => m.Title);
                    break;
            }

            return queryableList;
        }
        public async Task<Event?> GetAsync(int id)
        {
            return await _eventRepository
                .GetTableNoTracking()
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.EventId == id);
        }
        public async Task<Event> CreateAsync(Event newEvent)
        {
            newEvent.Title = newEvent.Title.Trim();
            newEvent.Description = newEvent.Description?.Trim();

            return await _eventRepository.AddAsync(newEvent);
        }
        public async Task<Event> UpdateAsync(Event eventToUpdate)
        {
            eventToUpdate.Title = eventToUpdate.Title.Trim();
            eventToUpdate.Description = eventToUpdate.Description?.Trim();

            return await _eventRepository.UpdateAsync(eventToUpdate);
        }
        public async Task<bool> DeleteAsync(Event eventToDelete)
        {
            _eventRepository.BeginTransaction();
            try
            {
                await _eventRepository.DeleteAsync(eventToDelete);
                _eventRepository.Commit();
                return true;
            }
            catch
            {
                _eventRepository.RollBack();
                return false;
            }
        }

        #endregion
    }
}
