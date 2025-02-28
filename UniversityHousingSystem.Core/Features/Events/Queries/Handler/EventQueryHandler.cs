using MediatR;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.Pagination;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Events.Queries.Handler
{
    public class EventQueryHandler : ResponseHandler,
        IRequestHandler<GetAllEventsQuery, Response<List<GetAllEventResponse>>>,
        IRequestHandler<GetComingEventsQuery, Response<List<GetComingEventsResponse>>>,
        IRequestHandler<GetEventsPaginatedListQuery, PaginatedList<GetEventsPaginatedListResponse>>,
        IRequestHandler<GetEventByIdQuery, Response<GetEventByIdResponse>>
    {
        #region Fields
        private readonly IEventService _eventService;
        #endregion
        #region Constructor
        public EventQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }
        #endregion
        #region handlers
        public async Task<Response<List<GetAllEventResponse>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var eventsList = await _eventService.GetAllAsync();

            var mappedEventsList = eventsList.Select(e => new GetAllEventResponse()
            {
                Title = e.Title,
                Date = e.Date,
                Description = e.Description,
                EventId = e.EventId,
                CreatedBy = $"{e.Employee.FirstName} {e.Employee.SecondName} {e.Employee.ThirdName}"
            }).ToList();

            return Success(mappedEventsList);
        }
        public async Task<Response<List<GetComingEventsResponse>>> Handle(GetComingEventsQuery request, CancellationToken cancellationToken)
        {
            var eventsList = await _eventService.GetComingEventsAsync();

            var mappedFutureEventsList = eventsList.Select(e => new GetComingEventsResponse()
            {
                Title = e.Title,
                Date = e.Date,
                Description = e.Description,
                EventId = e.EventId,
                CreatedBy = $"{e.Employee.FirstName} {e.Employee.SecondName} {e.Employee.ThirdName}"
            }).ToList();

            return Success(mappedFutureEventsList);
        }
        public async Task<Response<GetEventByIdResponse>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var askedEvent = await _eventService.GetAsync(request.EventId);

            if (askedEvent is null)
                return NotFound<GetEventByIdResponse>(String.Format(SharedResourcesKeys.NotFound, nameof(Event)));

            var mappedEvent = new GetEventByIdResponse()
            {
                EventId = askedEvent.EventId,
                Title = askedEvent.Title,
                Date = askedEvent.Date,
                Description = askedEvent.Description,
                CreatedBy = $"{askedEvent.Employee.FirstName} {askedEvent.Employee.SecondName} {askedEvent.Employee.ThirdName}"
            };

            return Success(mappedEvent);
        }

        public async Task<PaginatedList<GetEventsPaginatedListResponse>> Handle(GetEventsPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var eventsListQueryable = _eventService.GetAllQueryable(request.Search, request.EventOrdering);

            var paginatedList = await eventsListQueryable.Select(e => new GetEventsPaginatedListResponse
            {
                Title = e.Title,
                Date = e.Date,
                Description = e.Description,
                EventId = e.EventId,
                CreatedBy = $"{e.Employee.FirstName} {e.Employee.SecondName} {e.Employee.ThirdName}"
            }).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }
        #endregion
    }
}
