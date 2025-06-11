using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityHousingSystem.API.APIBases;
using UniversityHousingSystem.Core.Features.Events.Commands.Models;
using UniversityHousingSystem.Core.Features.Events.Queries.Models;
using UniversityHousingSystem.Data.AppMetaData;

namespace UniversityHousingSystem.API.Controllers
{
    [ApiController]
    public class EventsController : AppController
    {
        public EventsController(IMediator mediator) : base(mediator)
        {

        }

        #region Queries
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet(Router.EventRouting.list)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEventAsync()
        {
            var result = await _mediator.Send(new GetAllEventsQuery());
            return NewResult(result);
        }
        //[Authorize]
        [HttpGet(Router.EventRouting.coming)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetComingEventsAsync()
        {
            var result = await _mediator.Send(new GetComingEventsQuery());
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet(Router.EventRouting.paginated)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEventsPaginatedList([FromQuery] GetEventsPaginatedListQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        //[Authorize]
        [HttpGet(Router.EventRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetEventByIdQuery() { EventId = id });
            return NewResult(result);
        }
        #endregion
        #region Commands
        [Authorize(Roles = "Employee")]
        [HttpPost(Router.EventRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEvent([FromForm] CreateEventCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpPut(Router.EventRouting.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEvent([FromForm] UpdateEventCommand model)
        {
            var result = await _mediator.Send(model);
            return NewResult(result);
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpDelete(Router.EventRouting.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _mediator.Send(new DeleteEventCommand() { EventId = id });
            return NewResult(result);
        }
        #endregion
    }
}
