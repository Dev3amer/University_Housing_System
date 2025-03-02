using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Handler
{
    public class EventCommandHandler : ResponseHandler,
        IRequestHandler<CreateEventCommand, Response<GetEventByIdResponse>>,
        IRequestHandler<UpdateEventCommand, Response<GetEventByIdResponse>>,
        IRequestHandler<DeleteEventCommand, Response<bool>>
    {
        #region Fields
        private readonly IEventService _eventService;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion
        #region Constructor
        public EventCommandHandler(IEventService eventService, ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager)
        {
            _eventService = eventService;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }
        #endregion
        public async Task<Response<GetEventByIdResponse>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var currentEmployee = _userManager.Users
                .Where(u => u.Id == _currentUserService.GetUserId())
                .Select(u => u.Employee)
                .FirstOrDefault();

            if (currentEmployee is null)
                return Unauthorized<GetEventByIdResponse>(SharedResourcesKeys.UnAuthorized);

            var mappedEvent = new Data.Entities.Event()
            {
                Title = request.Title,
                Employee = currentEmployee,
                Date = request.Date,
                Description = request.Description
            };

            var addedEvent = await _eventService.CreateAsync(mappedEvent);
            var mappedResponse = new GetEventByIdResponse()
            {
                EventId = addedEvent.EventId,
                Title = addedEvent.Title,
                CreatedBy = $"{addedEvent.Employee.FirstName} {addedEvent.Employee.SecondName} {addedEvent.Employee.ThirdName}",
                Date = addedEvent.Date,
                Description = addedEvent.Description
            };

            return Created(mappedResponse, string.Format(SharedResourcesKeys.Created, nameof(Event)));
        }

        public async Task<Response<GetEventByIdResponse>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var oldEvent = await _eventService.GetAsync(request.EventId);

            if (oldEvent is null)
                return BadRequest<GetEventByIdResponse>(string.Format(SharedResourcesKeys.NotFound, nameof(Event)));

            oldEvent.Title = request.Title;
            oldEvent.Description = request.Description;
            oldEvent.Date = request.Date;

            var updatedEvent = await _eventService.UpdateAsync(oldEvent);
            var mappedResponse = new GetEventByIdResponse()
            {
                EventId = updatedEvent.EventId,
                Title = updatedEvent.Title,
                CreatedBy = $"{updatedEvent.Employee.FirstName} {updatedEvent.Employee.SecondName} {updatedEvent.Employee.ThirdName}",
                Date = updatedEvent.Date,
                Description = updatedEvent.Description
            };

            return Success(mappedResponse);
        }

        public async Task<Response<bool>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var searchedEvent = await _eventService.GetAsync(request.EventId);

            if (searchedEvent is null)
                return BadRequest<bool>(string.Format(SharedResourcesKeys.NotFound, nameof(Event)));

            var isDeleted = await _eventService.DeleteAsync(searchedEvent);
            return isDeleted ? Deleted<bool>(string.Format(SharedResourcesKeys.Deleted, nameof(Event))) : InternalServerError<bool>();
        }
    }
}
