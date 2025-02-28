using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Results;
using UniversityHousingSystem.Core.ResponseBases;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Core.Features.Events.Commands.Handler
{
    public class EventCommandHandler : ResponseHandler,
        IRequestHandler<CreateEventCommand, Response<GetEventByIdResponse>>
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
            // _currentUserService.GetUserId() => will work after implement security module 
            // for test use this hard coded id => "9D61EAB0-5680-46BD-9842-58F0CA2460CB"
            var currentEmployee = _userManager.Users
                .Where(u => u.Id == "9D61EAB0-5680-46BD-9842-58F0CA2460CB")
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

            return Success(mappedResponse);
        }
    }
}
